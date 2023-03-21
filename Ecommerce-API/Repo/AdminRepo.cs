using Ecommerce_API.Models;

namespace Ecommerce_API.Repo
{
    public class AdminRepo : IAdminRepo<Admin>
    {
        private readonly EcommerceContext db;
        public AdminRepo(EcommerceContext _db)
        {
            db = _db;
        }

        public List<Admin> GetAll()
        {
            return db.Admins.ToList();
        }
    }
}
