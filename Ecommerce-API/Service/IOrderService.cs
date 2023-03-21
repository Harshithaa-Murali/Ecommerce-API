using Ecommerce_API.Models;

namespace Ecommerce_API.Service
{
    public interface IOrderService<Order>
    {
        List<Order> GetAll();
        Order Get(int id);
        IEnumerable<Order> GetC(int cid);
        void AddOrder(Order o);
        void UpdateOrder(int id, Order o);
        void DeleteOrder(int id);
    }
}
