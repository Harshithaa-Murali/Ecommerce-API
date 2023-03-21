using Ecommerce_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_API.Repo
{
    public class OrderRepo : IOrderRepo<Order>
    {
        private readonly EcommerceContext db;
        public OrderRepo(EcommerceContext _db)
        {
            db = _db;
        }
        [HttpPost]
        public void AddOrder(Order o)
        {
            try
            {
                db.Orders.Add(o);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    if (OrderExists(o.OrderId))
                    {
                        throw new HttpRequestException("Order ID already exists");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public void DeleteOrder(int id)
        {
            var order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
        }
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            try
            {
                var order = db.Orders.Where(x => x.OrderId == id).Include(x => x.Cust).FirstOrDefault();
                return order;
            }
            catch(Exception)
            {
                throw new HttpRequestException("Server error in getting orders. Please try again");
            }
        }
        [HttpGet]
        public List<Order> GetAll()
        {
            try
            {
                return db.Orders.Include(x => x.Cust).ToList();
            }
            catch(Exception)
            {
                throw new HttpRequestException("Server error in getting orders. Please try again");
            }
        }

        [HttpPut("{id}")]
        public void UpdateOrder(int id, Order o)
        {
            db.Entry(o).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch(Exception)
            {
                throw new HttpRequestException("Server error in updating order. Please try again");
            }
        }
        [HttpGet("cid/{cid}")]
        public IEnumerable<Order> GetC(int cid)
        {
            try
            {
                var order = db.Orders.Where(x => x.CustId == cid).Include(x => x.Cust).ToList();
                return order;
            }
            catch(Exception)
            {
                throw new HttpRequestException("Server error in getting order list. Please try again");
            }
        }

        private bool OrderExists(int id)
        {
            return db.Orders.Any(e => e.OrderId == id);
        }

    }
}
