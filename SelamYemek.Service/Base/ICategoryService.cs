using SelamYemek.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SelamYemek.Service.Base
{
    public interface ICategoryService
    {
        Task<DataResult<List<Category>>> Read(CategoryFilter productFilter);

        Task<DataResult<Category>> Read(string id);

        Task<VoidResult> Create(Category category);

        Task<VoidResult> Delete(string id);
    }
}
