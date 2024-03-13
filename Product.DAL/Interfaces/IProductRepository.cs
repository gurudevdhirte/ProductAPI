namespace Product.DAL.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Entities.Product>> GetProducts();
        Task<Entities.Product> SaveProduct(Entities.Product product);
        Task<Entities.Product> GetProductById(int id);
    }
}
