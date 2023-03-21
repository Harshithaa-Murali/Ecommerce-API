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
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService<OrderDetail> serviceObj;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(OrderDetailsController));
        public OrderDetailsController(IOrderDetailService<OrderDetail> _serviceObj)
        {
            serviceObj = _serviceObj;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetails()
        {

            _log4net.Info("Order details retrieved");
            return serviceObj.GetAll();
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetail(int id)
        {
            var orderDetail = serviceObj.Get(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            _log4net.Info("Order details retrieved for" +id);
            return orderDetail;
        }
        [HttpGet("oid/{id}")]
        public async Task<ActionResult<List<OrderDetail>>> GetOrderDetails(int id)
        {
            var orderDetail = serviceObj.GetO(id);

            if (orderDetail == null)
            {
                return NotFound();
            }
            return orderDetail;
        }

        // PUT: api/OrderDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetail(int id, OrderDetail orderDetail)
        {
            serviceObj.UpdateOrderD(id, orderDetail);
            return Ok();
        }

        // POST: api/OrderDetails
        [HttpPost]
        public async Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetail orderDetail)
        {
            serviceObj.AddOrderD(orderDetail);
            return CreatedAtAction("GetOrderDetail", new { id = orderDetail.Id }, orderDetail);
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            serviceObj.DeleteOrderD(id);
            return Ok();
        }
    }
}
