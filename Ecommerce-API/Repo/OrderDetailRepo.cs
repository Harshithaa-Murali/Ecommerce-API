using Ecommerce_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_API.Repo
{
    public class OrderDetailRepo : IOrderDetailRepo<OrderDetail>
    {
        private readonly EcommerceContext db;
        public OrderDetailRepo(EcommerceContext _db)
        {
            db = _db;
        }
        [HttpPost]
        public void AddOrderD(OrderDetail o)
        {
            try
            {
                db.OrderDetails.Add(o);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    if (OrderExists(o.Id))
                    {
                        throw new HttpRequestException("ID already exists");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public void DeleteOrderD(int id)
        {
            var order = db.OrderDetails.Find(id);
            db.OrderDetails.Remove(order);
            db.SaveChanges();
        }

        [HttpGet("{id}")]
        public OrderDetail Get(int id)
        {
            try
            {
                var order = db.OrderDetails.Where(x => x.OrderId == id).FirstOrDefault();
                return order;
            }
            catch (Exception)
            {
                throw new HttpRequestException("Server error in getting order details. Please try again");
            }
        }

        [HttpGet]
        public List<OrderDetail> GetAll()
        {
            try
            {
                return db.OrderDetails.Include(x => x.PidNavigation).ToList();
            }
            catch (Exception)
            {
                throw new HttpRequestException("Server error in getting the order details. Please try again");
            }
        }

        [HttpGet("oid/{id}")]
        public List<OrderDetail> GetO(int id)
        {
            try
            {
                var order = db.OrderDetails.Where(x => x.OrderId == id).Include(x => x.PidNavigation).ToList();
                return order;
            }
            catch (Exception)
            {
                throw new HttpRequestException("Server error in getting the order details. Please try again");
            }
        }

        [HttpPut("{id}")]
        public void UpdateOrderD(int id, OrderDetail o)
        {
            db.Entry(o).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        private bool OrderExists(int? id)
        {
            return db.OrderDetails.Any(e => e.OrderId == id);
        }
    }
}
