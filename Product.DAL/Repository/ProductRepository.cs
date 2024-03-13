using Microsoft.EntityFrameworkCore;
using Product.DAL.Entities;
using Product.DAL.Interfaces;

namespace Product.DAL.Repository;

public class ProductRepository : IProductRepository
{
    private ProductDBContext context { get; }

    public ProductRepository(ProductDBContext dbContext)
    {
        this.context = dbContext;
    }   

    public async Task<List<Entities.Product>> GetProducts()
    {
        return await context.Products.ToListAsync().ConfigureAwait(false);
    }

    public async Task<Entities.Product> SaveProduct(Entities.Product product)
    {
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task<Entities.Product> GetProductById(int id)
    {
        return await context.Products.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
    }
}
