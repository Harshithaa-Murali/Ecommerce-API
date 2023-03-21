using Ecommerce_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_API.Repo
{
    public class LoginRepo : ILoginRepo<LoginDetail>
    {
        private readonly EcommerceContext db;
        public LoginRepo(EcommerceContext _db) { 
            db = _db;
        }
        [HttpPost]
        public void AddLogin(LoginDetail p)
        {
            try
            {
                db.LoginDetails.Add(p);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    throw new HttpRequestException("Customer ID already exists");
                }
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public void DeleteLogin(int id)
        {
            var order = db.LoginDetails.Find(id);
            db.LoginDetails.Remove(order);
            db.SaveChanges();
        }
        [HttpGet("{id}")]
        public LoginDetail Get(int id)
        {
            var order = db.LoginDetails.FirstOrDefault(x=>x.Cid == id);
            return order;
        }
        [HttpGet("un/{un}")]
        public LoginDetail GetU(string username)
        {
            var order = db.LoginDetails.FirstOrDefault(x=>x.Username == username);
            return order;
        }
        [HttpGet]
        public List<LoginDetail> GetAll()
        {
            return db.LoginDetails.ToList();
        }

        [HttpPut("{id}")]

        public void UpdateLogin(int id, LoginDetail p)
        {
            db.Entry(p).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new HttpRequestException("Server error in getting the order details. Please try again");
            }
        }
        private bool LoginDetailExists(int id)
        {
            return db.LoginDetails.Any(e => e.Cid == id);
        }
    }
}
