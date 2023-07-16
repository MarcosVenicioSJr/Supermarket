using Supermarket.API.Models;

namespace Supermarket.API.Mapper
{
    public static class ProductMapper
    {
        public static ProductDTO MapperDtoProduct(Product model)
        {
            ProductDTO product = new ProductDTO()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Quantity = model.Quantity,
                BarCode = model.BarCode,
                Description = model.Description,
            };

            return product;
        }
    }
}
