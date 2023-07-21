using Supermarket.API.Models;

namespace Supermarket.API.Mapper
{
    public static class ProductMapper
    {
        public static Product MapperDtoProduct(Product model)
        {
            Product product = new Product()
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
