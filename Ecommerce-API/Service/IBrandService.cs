using Ecommerce_API.Models;

namespace Ecommerce_API.Service
{
    public interface IBrandService<Brand>
    {
        List<Brand> GetAll();
    }
}
