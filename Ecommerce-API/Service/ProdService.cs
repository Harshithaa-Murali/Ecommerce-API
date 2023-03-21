using Ecommerce_API.Models;
using Ecommerce_API.Repo;

namespace LayeringEg.Service
{
    public class ProdService : IProdService<Product>
    {
        private readonly IProdRepo<Product> repoObj;
        public ProdService(IProdRepo<Product> _repoObj)
        {
            repoObj = _repoObj;
        }
        public void AddProd(Product p)
        {
            repoObj.AddProd(p);
        }

        public void DeleteProd(int id)
        {
            repoObj.DeleteProd(id);
        }

        public Product Get(int id)
        {
            Product prod = repoObj.Get(id);
            return prod;
        }

        public List<Product> GetAll()
        {
            return repoObj.GetAll();
        }

        public void UpdateProd(int id, Product p)
        {
            repoObj.UpdateProd(id,p);
        }
    }
}
