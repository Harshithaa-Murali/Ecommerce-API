using Ecommerce_API.Models;
using Ecommerce_API.Repo;

namespace Ecommerce_API.Service
{
    public class OrderService : IOrderService<Order>
    {
        private readonly IOrderRepo<Order> repoObj;
        public OrderService(IOrderRepo<Order> _repoObj )
        {
            repoObj = _repoObj;
        }
        public void AddOrder(Order o)
        {
            repoObj.AddOrder(o);
        }

        public void DeleteOrder(int id)
        {
            repoObj.DeleteOrder(id);
        }

        public Order Get(int id)
        {
            Order order = repoObj.Get(id);
            return order;
        }

        public List<Order> GetAll()
        {
            return repoObj.GetAll();    
        }

        public IEnumerable<Order> GetC(int cid)
        {
            return repoObj.GetC(cid);
        }

        public void UpdateOrder(int id, Order o)
        {
            repoObj.UpdateOrder(id, o);
        }
    }
}
