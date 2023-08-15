using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Data;
using Supermarket.API.Mapper;
using Supermarket.API.Models;
using Supermarket.API.Services.EmployeeService;
using Supermarket.API.Services.ProductService;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Route("Products")]
    public class ProductController : ControllerBase
    {

        private ProductResponse ProductResponse(Product product)
        {
            return new ProductResponse(product)
            {

                Product = product
            };
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> GetAll([FromServices] DataContext context)
        {
            try
            {
                List<Product> product = GetAllProducts.GetAll(context);
                var result = new
                {
                    Message = "Segue listas de produtos",
                    ProductList = product
                };

                return Ok(new {result});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id)
        {
            try
            {
                Product? product = await GetByIdAsync.GetByAsyncId(context, id);

                ProductResponse ProductResponse = new ProductResponse(product)
                {
                    Message = "Produto encontrado com sucesso.",
                    Product = product
                };

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromServices] DataContext context, [FromBody] Product model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Product product = ProductMapper.MapperDtoProduct(model);
                Product newProduct = await CreateProduct.CreateNewProduct(context, product);

                ProductResponse response = new ProductResponse(model)
                {
                    Message = "Produto criado com sucesso",
                    Product = newProduct
                };

                return Ok(new {response});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{barCode}")]
        public async Task<ActionResult<Product>> Delete([FromServices] DataContext context, string barCode)
        {
            try
            {
                Product deleteProduct = await DeleteProduct.Delete(context, barCode);

                ProductResponse response = new ProductResponse(deleteProduct)
                {
                    Message = "Produto deletado com sucesso!",
                    Product = deleteProduct
                };
                
                return Ok(new { response });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

