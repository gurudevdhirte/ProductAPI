using Microsoft.AspNetCore.Mvc;
using Product.BusinessLogic.Interfaces;
using Product.Models;

namespace ProductAPI.Controllers;

[ApiController]
public class ProductController : Controller
{
    private readonly IProductBLL productBLL;

    public ProductController(IProductBLL productBLL)
    {
        this.productBLL = productBLL;
    }

    [HttpGet]
    [Route("api/products")]
    public async Task<IActionResult> GetProducts()
    {
        try
        {
            List<Product.Models.ProductModel> lstProducts = await productBLL.GetProducts();
            return Ok(lstProducts);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
        }
    }

    [HttpPost]
    [Route("api/products")]
    public async Task<IActionResult> CreateProduct(ProductModel productModel)
    {
        try
        {
            ProductModel product = await productBLL.CreateProduct(productModel);
            return this.Created("", product);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new product");
        }
    }

    [HttpGet]
    [Route("api/products/{id}")]
    public async Task<IActionResult> GetProducts([FromRoute] int id)
    {
        try
        {
            if (id <= 0)
            {
                return NotFound($"Product with " + id + " not found");
            }

            ProductModel productModel = await productBLL.GetProductById(id);

            if (productModel == null)
            {
                return NotFound($"Product with id: " + id + " not found");
            }

            return this.Ok(productModel);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
        }
    }


}
