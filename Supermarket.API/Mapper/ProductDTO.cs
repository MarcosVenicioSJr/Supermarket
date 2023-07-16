using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Mapper
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string BarCode { get; set; }
    }
}
