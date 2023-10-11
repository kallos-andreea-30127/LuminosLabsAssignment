using E_CommerceApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ECommDBContext _eCommDBContext;

        public OrderController(ECommDBContext eCommDBContext)
        {
            _eCommDBContext = eCommDBContext;

        }

        //GET 

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = await _eCommDBContext.Orders.ToListAsync();
            if (orders == null) { return NotFound(); }

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<Order> Get(int id)
        {
            var order = await _eCommDBContext.Orders.FirstOrDefaultAsync(order => order.orderID == id);
            return order;
        }
        /*
        [HttpGet("{userID}")]
        public async Task<IActionResult> GetOrders(int userID)
        {
            var orders = await _eCommDBContext.Orders.AnyAsync(order => order.userID == userID);
            if(orders == null) { return NotFound(); }
            return Ok(orders);
        }*/

        //POST

        [HttpPost]
        public async Task<int> Create(Order order)
        {
            _eCommDBContext.Orders.Add(order);
            await _eCommDBContext.SaveChangesAsync();
            return order.orderID;
        }

        //PUT

        [HttpPut("{id}")]
        public async Task<bool> Update(int id, Order order)
        {
            var existingOrder = await _eCommDBContext.Orders.FirstOrDefaultAsync(i => i.orderID == id);
            existingOrder = order; //might need to do it propriety one by one
            var result = await _eCommDBContext.SaveChangesAsync();
            return result > 0;
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var order = await _eCommDBContext.Orders.FirstOrDefaultAsync(order => order.orderID == id);
            _eCommDBContext.Orders.Remove(order);
            var result = await _eCommDBContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
