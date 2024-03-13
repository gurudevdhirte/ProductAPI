using Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.BusinessLogic.Interfaces
{
    public interface IProductBLL
    {
        Task<List<ProductModel>> GetProducts();
        Task<ProductModel> CreateProduct(ProductModel productModel);
        Task<ProductModel> GetProductById(int id);
    }
}
