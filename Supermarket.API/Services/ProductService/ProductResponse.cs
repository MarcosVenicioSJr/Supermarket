using Supermarket.API.Models;

namespace Supermarket.API.Services.ProductService
{
    public class ProductResponse
    {
        public string Message { get; set; }
        public Product Product { get; set; }
    }
}
