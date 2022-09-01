using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        // injecting StoreContext into ProductsController
        // when request comes in it hits Products controller - new instance of controller made
        // will look at dependencies ie context parameter - will create new instance of storecontext
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() {
            // ActionResult means some kind of Http response status will be returned
            // _context.products refers to products table. Context being used to query table
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) {
            return await _context.Products.FindAsync(id);
        }
    }
}