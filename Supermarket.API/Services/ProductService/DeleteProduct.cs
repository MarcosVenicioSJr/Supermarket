using Microsoft.AspNetCore.Mvc;
using Supermarket.API.DAO;
using Supermarket.API.Data;
using Supermarket.API.Models;

namespace Supermarket.API.Services.ProductService
{
    public static class DeleteProduct
    {
        public static async Task<Product> Delete(DataContext context, string barCode)
        {
            ProductDao productDao = new ProductDao(context);

            Task<Product> task = productDao.GetProductByBarCode(barCode);
            Product product = task.Result;

            if (product == null)
                throw new Exception("Produto não encontrado.");

            try
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            return product;
        }
    }
}
