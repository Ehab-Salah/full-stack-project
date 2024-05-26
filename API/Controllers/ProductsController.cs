
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext context;
        public ProductsController(StoreContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> getProducts(){
            var products=await context.products.ToListAsync();
            return products;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProduct(int id){

            return await context.products.FindAsync(id);
        }
    }
}