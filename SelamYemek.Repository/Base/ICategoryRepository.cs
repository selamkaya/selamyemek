using SelamYemek.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SelamYemek.Repository.Base
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> Filter(string name);
    }
}
