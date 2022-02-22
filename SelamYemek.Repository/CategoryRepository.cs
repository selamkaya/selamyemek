using SelamYemek.Data;
using SelamYemek.Repository.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SelamYemek.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<List<Category>> Filter(string name)
        {
            FilterDefinition<Category> filter = Builders<Category>.Filter.Empty;

            if (!string.IsNullOrEmpty(name))
                filter = Builders<Category>.Filter.Eq("name", name);

            var data = await Collection.FindAsync(filter);
            return data.ToList();
        }
    }
}
