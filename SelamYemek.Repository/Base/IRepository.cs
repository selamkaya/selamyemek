using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SelamYemek.Repository.Base
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Read();

        Task<TEntity> Read(string id);

        Task Add(TEntity entity);

        Task<TEntity> UpdateAsync(string id, TEntity entity);

        Task<TEntity> DeleteAsync(string id);
    }
}
