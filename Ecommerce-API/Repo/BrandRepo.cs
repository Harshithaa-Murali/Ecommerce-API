using Ecommerce_API.Models;

namespace Ecommerce_API.Repo
{
    public class BrandRepo : IBrandRepo<Brand>
    {
        private readonly EcommerceContext db;
        public BrandRepo(EcommerceContext _db)
        {
            db = _db;
        }
        public List<Brand> GetAll()
        {
            return db.Brands.ToList();  
        }
    }
}
