using Supermarket.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Name é obrigatório")]
        [StringLength(50)]
        public string Name { get; set; }

        public string TaxNumber { get; set; }

        public DateTime LastPurchase { get; set; }
    }
}
