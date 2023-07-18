using Microsoft.AspNetCore.Mvc;
using Supermarket.API.DAO;
using Supermarket.API.Data;
using Supermarket.API.Models;

namespace Supermarket.API.Services.ProductService
{
    public static class DeleteProduct
    {
        public static bool Delete([FromServices] DataContext context, string barCode)
        {
            ProductDao productDao = new ProductDao();

            var product = productDao.GetProductByBarCode(context, barCode);

            return true;
        }
    }
}
