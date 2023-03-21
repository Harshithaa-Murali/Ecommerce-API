using Ecommerce_API.Models;

namespace Ecommerce_API.Repo
{
    public interface IOrderDetailRepo<OrderDetail>
    {
        List<OrderDetail> GetAll();
        OrderDetail Get(int id);
        List<OrderDetail> GetO(int oid);
        void AddOrderD(OrderDetail o);
        void UpdateOrderD(int id, OrderDetail o);
        void DeleteOrderD(int id);
    }
}
