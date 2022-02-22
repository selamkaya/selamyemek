using SelamYemek.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SelamYemek.Service.Base
{
    public interface IProductService
    {
        Task<DataResult<List<Product>>> Read(ProductFilter productFilter);

        Task<DataResult<Product>> Read(string id);

        Task<VoidResult> Create(Product product);

        Task<VoidResult> Delete(string id);
    }
}
