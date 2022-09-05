using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        // injecting StoreContext into ProductsController
        // when request comes in it hits Products controller - new instance of controller made
        // will look at dependencies ie context parameter - will create new instance of storecontext
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
           
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() {
            // ActionResult means some kind of Http response status will be returned
            // _context.products refers to products table. Context being used to query table
            var products = await _repo.GetProductsAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) {
            return await _repo.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            // cant directly return ireadonlylist type so need to wrap in Ok() response
            return Ok(await _repo.GetProductBrandsAsync());
        }

         [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }
    }
}