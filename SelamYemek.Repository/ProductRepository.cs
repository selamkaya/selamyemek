using SelamYemek.Data;
using SelamYemek.Repository.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SelamYemek.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<List<Product>> Filter(string categoryId, string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Empty;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(categoryId))
                 filter = Builders<Product>.Filter.And(Builders<Product>.Filter.Eq("name", name), Builders<Product>.Filter.Eq("categoryId", categoryId));

            var data = await Collection.FindAsync(filter);
            return data.ToList();
        }
    }
}
