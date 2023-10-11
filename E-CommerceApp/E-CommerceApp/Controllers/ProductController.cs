using E_CommerceApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ECommDBContext _eCommDBContext;

        public ProductController(ECommDBContext eCommDBContext)
        {
            _eCommDBContext = eCommDBContext;

        }

        //GET

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _eCommDBContext.Products.ToListAsync();
            if (products == null) { return NotFound(); }

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            var product = await _eCommDBContext.Products.FirstOrDefaultAsync(product => product.productID == id);
            return product;
        }

        //POST

        [HttpPost]
        public async Task<int> Create(Product product)
        {
            _eCommDBContext.Products.Add(product);
            await _eCommDBContext.SaveChangesAsync();
            return product.productID;
        }

        //PUT

        [HttpPut("{id}")]
        public async Task<bool> Update(int id, Product product)
        {
            var existingProduct = await _eCommDBContext.Products.FirstOrDefaultAsync(i => i.productID == id);
            existingProduct = product; //might need to do it propriety one by one
            var result = await _eCommDBContext.SaveChangesAsync();
            return result > 0;
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var product = await _eCommDBContext.Products.FirstOrDefaultAsync(product => product.productID == id);
            _eCommDBContext.Products.Remove(product);
            var result = await _eCommDBContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
