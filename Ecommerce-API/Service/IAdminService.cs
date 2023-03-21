using Ecommerce_API.Models;

namespace Ecommerce_API.Service
{
    public interface IAdminService<Admin>
    {
        List<Admin> GetAll();
    }
}
