using Ecommerce_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_API.Repo
{
    public class ProdRepo : IProdRepo<Product>
    {
        private readonly EcommerceContext db;
        public ProdRepo(EcommerceContext _db)
        {
            db = _db;
        }
        [HttpPost]

        public void AddProd(Product p)
        {
            try
            {
                db.Products.Add(p);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    if (ProductExists(p.Pid))
                    {
                        throw new HttpRequestException("Product ID already exists");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public void DeleteProd(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
        }
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            try
            {
                try
                {
                    var product = db.Products.Where(x => x.Pid == id).Include(x => x.Brand).FirstOrDefault();
                    return product;
                }
                catch (HttpRequestException e)
                {
                    throw new HttpRequestException("Server error in getting product");
                }
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException(e.Message);
            }
        }
        [HttpGet]
        public List<Product> GetAll()
        {
            try
            {
                return db.Products.Include(x => x.Brand).ToList();
            }
            catch(Exception)
            {
                throw new HttpRequestException("Server error in getting products");
            }
        }

        [HttpPut("{id}")]
        public void UpdateProd(int id,Product p)
        {
            db.Entry(p).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new HttpRequestException("Server error in updation. Please try again");
            }
        }
        private bool ProductExists(int id)
        {
            return db.Products.Any(e => e.Pid == id);
        }
    }
}
