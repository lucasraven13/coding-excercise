using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.BL.Models;
using ProductsApi.BL.Interfaces;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/products
        [HttpGet]
        public async Task<IEnumerable<ProductRecord>> GetAll()
        {
            return await _productService.SelectAllAsync();
        }

        // GET api/products/active
        [HttpGet("active")]
        public async Task<IEnumerable<ProductRecord>> GetAllActive()
        {
            return await _productService.SelectActiveAsync();
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public async Task<ProductRecord> Get(int id)
        {
            return await _productService.SelectProductByIdAsync(id);
        }

        // POST api/products
        [HttpPost]
        public async Task<int> Post([FromBody]ProductRecord record)
        {
            return await _productService.AddNewAsync(record);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public async Task<int> Put(int id, [FromBody]ProductRecord record)
        {
             return await _productService.UpdateAsync(id, record);
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _productService.DeleteAsync(id);
        }
    }
}
