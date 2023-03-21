using Ecommerce_API.Models;

namespace Ecommerce_API.Repo
{
    public interface IAdminRepo<Admin>
    {
        List<Admin> GetAll();
    }
}
