using SelamYemek.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SelamYemek.Repository.Base
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> Filter(string categoryId, string name);
    }
}
