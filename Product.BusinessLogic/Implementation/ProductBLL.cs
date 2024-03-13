using Product.BusinessLogic.Interfaces;
using Product.DAL.Interfaces;
using Product.Models;

namespace Product.BusinessLogic.Implementation;

public class ProductBLL : IProductBLL
{
    private readonly IProductRepository productRepo;

    public ProductBLL(IProductRepository productRepo)
    {
        this.productRepo = productRepo;
    }

    public async Task<List<ProductModel>> GetProducts()
    {
        List<DAL.Entities.Product> lstProducts = await this.productRepo.GetProducts();

        List<ProductModel> lstProductModel = new ();
        foreach (DAL.Entities.Product product in lstProducts)
        {
            ProductModel productModel = new()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price.Value,
                Description = product.Description,
                Category = product.Category
            };

            lstProductModel.Add(productModel);
        }

        return lstProductModel;
    }

    public async Task<ProductModel> CreateProduct(ProductModel productModel)
    {
        DAL.Entities.Product product = new()
        {
            Name = productModel.Name,
            Price = productModel.Price,
            Description = productModel.Description,
            Category = productModel.Category
        };

        await productRepo.SaveProduct(product);
        productModel.Id = product.Id;
        return productModel;
    }

    public async Task<ProductModel> GetProductById(int id)
    {
        DAL.Entities.Product product = await this.productRepo.GetProductById(id);
        
        if(product==null)
        {
            return null;
        }

        return new()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price.Value,
            Description = product.Description,
            Category = product.Category
        };
    }
}
