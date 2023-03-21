namespace LayeringEg.Service
{
    public interface IProdService<Product>
    {
        List<Product> GetAll();
        Product Get(int id);
        void AddProd(Product p);
        void UpdateProd(int id, Product p);
        void DeleteProd(int id);
    }
}
