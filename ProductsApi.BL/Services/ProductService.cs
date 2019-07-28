using System.Collections.Generic;
using ProductsApi.BL.Interfaces;
using System.Threading.Tasks;
using ProductsApi.BL.Models;
using ProductsApi.DAL.Intrefaces;
using AutoMapper;

namespace ProductsApi.BL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductRecord>> SelectAllAsync()
        {
            return _mapper.Map<List<ProductRecord>>(await _productRepository.SelectAllAsync());
        }

        public async Task<ProductRecord> SelectProductByIdAsync(int id)
        {
            return _mapper.Map<ProductRecord>(await _productRepository.SelectProductByIdAsync(id));
        }
        public async Task<List<ProductRecord>> SelectActiveAsync()
        {
            return _mapper.Map<List<ProductRecord>>(await _productRepository.SelectActiveAsync());
        }
        public async Task DeleteAsync(int productId)
        {
            await _productRepository.DeleteAsync(productId);
        }
        public async Task<int> AddNewAsync(ProductRecord product)
        {
            return await _productRepository.AddNewAsync(product.ProductName, product.SupplierID, product.CategoryID,
               product.QuantityPerUnit, product.UnitPrice, product.UnitsInStock, product.UnitsOnOrder, product.ReorderLevel, product.Discontinued);
        }
        public async Task<int> UpdateAsync(int productId, ProductRecord product)
        {
            return await _productRepository.UpdateAsync(productId, product.ProductName, product.SupplierID, product.CategoryID,
               product.QuantityPerUnit, product.UnitPrice, product.UnitsInStock, product.UnitsOnOrder, product.ReorderLevel, product.Discontinued);
        }
    }
}