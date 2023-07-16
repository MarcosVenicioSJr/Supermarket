using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Name é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo Name deve conter pelo menos 3 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Price é obrigatório.")]
        [Range((double) 0.05m, (double) decimal.MaxValue, ErrorMessage = "O campo Price deve ser no mínimo 0.5 centavos")]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(1, (double) int.MaxValue, ErrorMessage = "O produto deve conter pelo menos 1 quantidade.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "O campo BarCode é obrigatório.")]
        [MinLength(13, ErrorMessage = "O campo BarCode deve conter no mínimo 13 caracteres.")]
        [MaxLength(13, ErrorMessage = "O campo BarCode deve conter no máximo 13 caracteres.")]
        public string BarCode { get; set; }
    }
}
