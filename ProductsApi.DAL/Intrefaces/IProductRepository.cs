using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsApi.DAL.Models;

namespace ProductsApi.DAL.Intrefaces
{
    public interface IProductRepository
    {
        Task<List<Product>> SelectAllAsync();
        Task<Product> SelectProductByIdAsync(int id);
        Task<List<Product>> SelectActiveAsync();
        Task DeleteAsync(int productId);
        Task<int> AddNewAsync(string productName,
            int supplierId,
            int categoryId,
            string quantityPerUnit,
            decimal unitPrice,
            int unitsInStock,
            int unitsOnOrder,
            int reorderLevel,
            bool discontinued);
        Task<int> UpdateAsync(int productId,
            string productName,
            int supplierId,
            int categoryId,
            string quantityPerUnit,
            decimal unitPrice,
            int unitsInStock,
            int unitsOnOrder,
            int reorderLevel,
            bool discontinued);
    }
}