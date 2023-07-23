using Microsoft.AspNetCore.Mvc;
using Supermarket.API.DAO;
using Supermarket.API.Data;
using Supermarket.API.Models;
using System.Threading.Tasks;

namespace Supermarket.API.Services.ProductService
{
    public static class GetAllProducts
    {
        public static List<Product> GetAll([FromServices] DataContext context)
        {
            ProductDao productDao = new ProductDao(context);
            Task<List<Product>> task = productDao.GetAllProducts();
            List<Product> products = task.Result;
            return products;
        }
    }
}
