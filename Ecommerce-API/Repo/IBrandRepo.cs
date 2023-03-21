using Ecommerce_API.Models;

namespace Ecommerce_API.Repo
{
    public interface IBrandRepo<Brand>
    {
        List<Brand> GetAll();
    }
}
