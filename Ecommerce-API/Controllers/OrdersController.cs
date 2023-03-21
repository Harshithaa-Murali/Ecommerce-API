using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerce_API.Models;
using Ecommerce_API.Service;

namespace Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService<Order> serviceObj;
        public OrdersController(IOrderService<Order> _serviceObj)
        {
            serviceObj = _serviceObj;
        }
        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return serviceObj.GetAll();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = serviceObj.Get(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }
        [HttpGet("cid/{cid}")]
        public IEnumerable<Order> GetCOrder(int cid)
        {
            var order = serviceObj.GetC(cid);
            return order;
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        { 
            serviceObj.UpdateOrder(id, order);
            return Ok();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            serviceObj.AddOrder(order);
            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
           serviceObj.DeleteOrder(id);
           return Ok();
        }

    }
}
