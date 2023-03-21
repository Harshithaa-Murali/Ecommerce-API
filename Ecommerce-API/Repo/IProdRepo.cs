namespace Ecommerce_API.Repo
{
    public interface IProdRepo<Product>
    {
        List<Product> GetAll();
        Product Get(int id);
        void AddProd(Product p);
        void UpdateProd(int id,Product p);
        void DeleteProd(int id);
    }
}
