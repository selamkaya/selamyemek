using SelamYemek.Data;
using SelamYemek.Data.Base;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace SelamYemek.Repository.Base
{
    public abstract class RepositoryBase<TEntity> where TEntity : EntityBase
    {
        #region Fields
        protected readonly IMongoContext _dbContext;
        protected readonly IMongoCollection<TEntity> Collection;
        #endregion

        #region Constructors
        public RepositoryBase(IMongoContext dbContext)
        {
            _dbContext = dbContext;
            Collection = _dbContext.Collection<TEntity>();
        }
        #endregion

        #region Methods
        public IQueryable<TEntity> Read(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                ? Collection.AsQueryable()
                : Collection.AsQueryable().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> Read()
        {
            var data = await Collection.FindAsync(Builders<TEntity>.Filter.Empty);
            return data.ToList();
        }

        public async Task<TEntity> Read(string id)
        {
            ObjectId _id = ObjectId.Parse(id);
            return await Collection.Find(x => x.Id == _id).FirstOrDefaultAsync();
        }

        public Task Add(TEntity entity)
        {
            return Collection.InsertOneAsync(entity);
        }

        public async Task<TEntity> UpdateAsync(string id, TEntity entity)
        {
            ObjectId _id = ObjectId.Parse(id);
            return await Collection.FindOneAndReplaceAsync(x => x.Id == _id, entity);
        }

        public async Task<TEntity> DeleteAsync(string id)
        {
            ObjectId _id = ObjectId.Parse(id);
            return await Collection.FindOneAndDeleteAsync(x => x.Id == _id);
        }
        #endregion
    }
}
