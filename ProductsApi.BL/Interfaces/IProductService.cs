using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsApi.BL.Models;

namespace ProductsApi.BL.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductRecord>> SelectAllAsync();
        Task<ProductRecord> SelectProductByIdAsync(int id);
        Task<List<ProductRecord>> SelectActiveAsync();
        Task DeleteAsync(int productId);
        Task<int> AddNewAsync(ProductRecord product);
        Task<int> UpdateAsync(int productId, ProductRecord product);
    }
}