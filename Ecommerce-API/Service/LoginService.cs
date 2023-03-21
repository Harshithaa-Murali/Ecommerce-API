using Ecommerce_API.Models;
using Ecommerce_API.Repo;

namespace Ecommerce_API.Service
{
    public class LoginService : ILoginService<LoginDetail>
    {
        private readonly ILoginRepo<LoginDetail> repoObj;
        public LoginService(ILoginRepo<LoginDetail> _repoObj)
        {
            repoObj = _repoObj;
        }

        public void AddLogin(LoginDetail p)
        {
            repoObj.AddLogin(p);
        }

        public void DeleteLogin(int id)
        {
            repoObj.DeleteLogin(id);
        }

        public LoginDetail Get(int id)
        {
            LoginDetail login = repoObj.Get(id);
            return login;
        }

        public List<LoginDetail> GetAll()
        {
            return repoObj.GetAll();
        }

        public LoginDetail GetU(string username)
        {
            return repoObj.GetU(username);
        }

        public void UpdateLogin(int id, LoginDetail p)
        {
            repoObj.UpdateLogin(id, p);
        }
    }
}
