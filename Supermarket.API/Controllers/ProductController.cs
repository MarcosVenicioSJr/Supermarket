using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Data;
using Supermarket.API.Mapper;
using Supermarket.API.Models;
using Supermarket.API.Services.ProductService;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Route("Products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id)
        {
            Product? product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                return NotFound(new { message = "Produto não encontrado" });

            return Ok(product);
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

                var response = new ProductResponse()
                {
                    Message = "Produto criado com sucesso",
                    Product = newProduct
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Product>> Delete([FromServices] DataContext context, [FromBody] string barCode)
        {
            Product deleteProduct = await DeleteProduct.Delete(context, barCode);

            return Ok(new { message = $"Produto {deleteProduct.Name} foi excluído com sucesso!" });
        }
    }
}
