using Ecommerce_API.Models;
using Ecommerce_API.Repo;

namespace Ecommerce_API.Service
{
    public class AdminService : IAdminService<Admin>
    {
        private readonly IAdminRepo<Admin> repoObj;
        public AdminService(IAdminRepo<Admin> _repoObj)
        {
            repoObj = _repoObj;
        }

        public List<Admin> GetAll()
        {
            return repoObj.GetAll();
        }
    }
}
