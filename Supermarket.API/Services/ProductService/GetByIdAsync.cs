using Supermarket.API.DAO;
using Supermarket.API.Data;
using Supermarket.API.Models;

namespace Supermarket.API.Services.ProductService
{
    public static class GetByIdAsync
    {
        public static async Task<Product> GetByAsyncId(DataContext dataContext, int id)
        {
            ProductDao productDao = new ProductDao(dataContext);

            Product product = await productDao.GetById(id);
            if (product == null)
                throw new Exception("Produto não encontrado.");

            return product;
        }
    }
}
