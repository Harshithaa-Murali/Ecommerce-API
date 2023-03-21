using Ecommerce_API.Models;

namespace Ecommerce_API.Repo
{
    public interface ILoginRepo<LoginDetail>
    {
        List<LoginDetail> GetAll();
        LoginDetail Get(int id);
        LoginDetail GetU(string username);
        void AddLogin(LoginDetail p);
        void UpdateLogin(int id, LoginDetail p);
        void DeleteLogin(int id);
    }
}
