using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Data;
using Supermarket.API.Mapper;
using Supermarket.API.Models;

namespace Supermarket.API.DAO
{
    public class ProductDao
    {
        public async Task<bool> ExistsProduct([FromServices] DataContext context, string barCode)
        {
            Product? product = await context.Products.FirstOrDefaultAsync(x => x.BarCode == barCode);

            return product != null;
        }

        public async Task<Product> GetProductByBarCode([FromServices] DataContext context, string barCode)
        {
            Product product = await context.Products.FirstOrDefaultAsync(x => x.BarCode == barCode);
            return product;
        }

        public async void Save([FromServices] DataContext context, Product product)
        {
            var productEntity = ProductMapper.MapperDtoProduct(product);
            context.Products.Add(productEntity);
            await context.SaveChangesAsync();
        }
    }
}
