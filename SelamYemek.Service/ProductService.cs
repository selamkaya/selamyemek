using SelamYemek.Caching.Base;
using SelamYemek.Common;
using SelamYemek.Repository.Base;
using SelamYemek.Service.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SelamYemek.Service
{
    public class ProductService : IProductService
    {
        #region Fields
        private readonly IRedisOperation _redisOperation;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        #endregion

        #region Constructors
        public ProductService(IRedisOperation redisOperation, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            #region Fields
            _redisOperation = redisOperation;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            #endregion
        }

        #endregion

        #region Methods
        public async Task<DataResult<List<Product>>> Read(ProductFilter productFilter)
        {
            DataResult<List<Product>> dataResult = new DataResult<List<Product>>();

            ExceptionHandler.Handle(() =>
            {
                var productsEntity = _productRepository.Filter(productFilter.CategoryId, productFilter.Name).Result;

                dataResult.Data = new List<Product>();

                foreach (var p in productsEntity)
                {
                    dataResult.Data.Add(new Product()
                    {
                        Id = p.Id.ToString(),
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Currency = p.Currency,
                        CategoryId = p.CategoryId
                    });
                }
            }, (exception) =>
            {
                dataResult.Failed = true;
                dataResult.Message = "NotFound";
            });

            return await Task.FromResult(dataResult);
        }

        public async Task<DataResult<Product>> Read(string id)
        {
            DataResult<Product> dataResult = new DataResult<Product>();

            ExceptionHandler.Handle(() =>
            {
                dataResult.Data = _redisOperation.Get<Product>(() => ReadDetail(id), $"ProductDetail:{id}.");
            }, (exception) =>
            {
                dataResult.Failed = true;
                dataResult.Message = "NotFound";
            });

            return await Task.FromResult(dataResult);
        }

        public async Task<VoidResult> Create(Product product)
        {
            VoidResult dataResult = new VoidResult();
            ExceptionHandler.Handle(() =>
            {
                var productEntity = new Data.Product()
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Currency = product.Currency,
                    CategoryId = product.CategoryId
                };
                _productRepository.Add(productEntity);
                dataResult.Code = 201;
            }, (exception) =>
            {
                dataResult.Failed = true;
                dataResult.Message = "AddError";
            });

            return await Task.FromResult(dataResult);
        }

        public async Task<VoidResult> Delete(string id)
        {
            VoidResult dataResult = new VoidResult();
            ExceptionHandler.Handle(() =>
            {
                _productRepository.DeleteAsync(id);

            }, (exception) =>
            {
                dataResult.Failed = true;
                dataResult.Message = "AddError";
            });

            return await Task.FromResult(dataResult);
        }
        #endregion

        #region PrivateMethods
        private Product ReadDetail(string id)
        {
            var productEntity = _productRepository.Read(id).Result;
            var categoryEntity = _categoryRepository.Read(productEntity.CategoryId).Result;

            var product = new Product()
            {
                Id = productEntity.Id.ToString(),
                Name = productEntity.Name,
                Description = productEntity.Description,
                Price = productEntity.Price,
                Currency = productEntity.Currency,
                Category = new Category()
                {
                    Id = categoryEntity.Id.ToString(),
                    Name = categoryEntity.Name,
                    Description = categoryEntity.Description
                }
            };

            return product;
        }
        #endregion
    }
}
