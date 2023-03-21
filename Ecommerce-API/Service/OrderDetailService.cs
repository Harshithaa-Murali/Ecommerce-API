using Ecommerce_API.Models;
using Ecommerce_API.Repo;

namespace Ecommerce_API.Service
{
    public class OrderDetailService : IOrderDetailService<OrderDetail>
    {
        private readonly IOrderDetailRepo<OrderDetail> repoObj;
        public OrderDetailService(IOrderDetailRepo<OrderDetail> _repoObj)
        {
            repoObj = _repoObj;
        }

        public void AddOrderD(OrderDetail o)
        {
            repoObj.AddOrderD(o);
        }

        public void DeleteOrderD(int id)
        {
            repoObj.DeleteOrderD(id);
        }

        public OrderDetail Get(int id)
        {
            var order = repoObj.Get(id);
            return order;
        }

        public List<OrderDetail> GetAll()
        {
            return repoObj.GetAll();
        }

        public List<OrderDetail> GetO(int oid)
        {
            return repoObj.GetO(oid);
        }

        public void UpdateOrderD(int id, OrderDetail o)
        {
            repoObj.UpdateOrderD(id, o);
        }
    }
}
