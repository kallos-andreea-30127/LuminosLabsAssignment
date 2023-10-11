using E_CommerceApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsOrderController : ControllerBase
    {
        private ECommDBContext _eCommDBContext;

        public ProductsOrderController(ECommDBContext eCommDBContext)
        {
            _eCommDBContext = eCommDBContext;
        }

        //GET 

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var prodOs = await _eCommDBContext.ProductsOrders.ToListAsync();
            if (prodOs == null) { return NotFound(); }

            return Ok(prodOs);
        }

        [HttpGet("{id}")]
        public async Task<ProductsOrder> Get(int id)
        {
            var prodO = await _eCommDBContext.ProductsOrders.FirstOrDefaultAsync(prodO => prodO.poID == id);
            return prodO;
        }

        //POST

        [HttpPost]
        public async Task<int> Create(ProductsOrder prodO)
        {
            _eCommDBContext.ProductsOrders.Add(prodO);
            await _eCommDBContext.SaveChangesAsync();
            return prodO.poID;
        }

        //PUT

        [HttpPut("{id}")]
        public async Task<bool> Update(int id, ProductsOrder prodO)
        {
            var existingProductsOrders = await _eCommDBContext.ProductsOrders.FirstOrDefaultAsync(i => i.poID == id);
            existingProductsOrders = prodO; //might need to do it propriety one by one
            var result = await _eCommDBContext.SaveChangesAsync();
            return result > 0;
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var prodO = await _eCommDBContext.ProductsOrders.FirstOrDefaultAsync(prodO => prodO.poID == id);
            _eCommDBContext.ProductsOrders.Remove(prodO);
            var result = await _eCommDBContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
