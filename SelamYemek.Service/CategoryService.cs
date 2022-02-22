using SelamYemek.Common;
using SelamYemek.Repository.Base;
using SelamYemek.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SelamYemek.Service
{
    public class CategoryService : ICategoryService
    {
        #region Fields
        private readonly ICategoryRepository _categoryRepository;
        #endregion

        #region Constructors
        public CategoryService(ICategoryRepository categoryRepository)
        {
            #region Fields
            _categoryRepository = categoryRepository;
            #endregion
        }

        #endregion

        #region Methods
        public async Task<DataResult<List<Category>>> Read(CategoryFilter productFilter)
        {
            DataResult<List<Category>> dataResult = new DataResult<List<Category>>();

            ExceptionHandler.Handle(() =>
            {
                var categorysEntity = _categoryRepository.Filter(productFilter.Name).Result;

                dataResult.Data = new List<Category>();

                foreach (var p in categorysEntity)
                {
                    dataResult.Data.Add(new Category()
                    {
                        Id = p.Id.ToString(),
                        Name = p.Name,
                        Description = p.Description
                    });
                }
            }, (exception) =>
            {
                dataResult.Failed = true;
                dataResult.Message = "NotFound";
            });

            return await Task.FromResult(dataResult);
        }

        public async Task<DataResult<Category>> Read(string id)
        {
            DataResult<Category> dataResult = new DataResult<Category>();

            ExceptionHandler.Handle(() =>
            {
                var categoryEntity = _categoryRepository.Read(id).Result;

                var category = new Category()
                {
                    Id = categoryEntity.Id.ToString(),
                    Name = categoryEntity.Name,
                    Description = categoryEntity.Description
                };
                dataResult.Data = category;
            }, (exception) =>
            {
                dataResult.Failed = true;
                dataResult.Message = "NotFound";
            });

            return await Task.FromResult(dataResult);
        }

        public async Task<VoidResult> Create(Category Category)
        {
            VoidResult dataResult = new VoidResult();
            ExceptionHandler.Handle(() =>
            {
                var CategoryEntity = new Data.Category()
                {
                    Name = Category.Name,
                    Description = Category.Description
                };
                _categoryRepository.Add(CategoryEntity);

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
                _categoryRepository.DeleteAsync(id);

            }, (exception) =>
            {
                dataResult.Failed = true;
                dataResult.Message = "AddError";
            });

            return await Task.FromResult(dataResult);
        }
        #endregion
    }
}
