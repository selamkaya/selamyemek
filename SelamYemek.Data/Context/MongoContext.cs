using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelamYemek.Data
{
    public class MongoContext :IMongoContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue("MongoConnectionString", ""));
            if (client != null) _database = client.GetDatabase(configuration.GetValue("MondoDbName", ""));
        }

        public IMongoCollection<TEntity> Collection<TEntity>()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
    }

    public interface IMongoContext
    {
        IMongoCollection<TEntity> Collection<TEntity>();
    }
}



