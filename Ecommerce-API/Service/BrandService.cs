using Ecommerce_API.Models;
using Ecommerce_API.Repo;

namespace Ecommerce_API.Service
{
    public class BrandService : IBrandService<Brand>
    {
        private readonly IBrandRepo<Brand> repoObj;
        public BrandService(IBrandRepo<Brand> _repoObj)
        {
            repoObj = _repoObj;
        }
        public List<Brand> GetAll()
        {
            return repoObj.GetAll();
        }
    }
}
