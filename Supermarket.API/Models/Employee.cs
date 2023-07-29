using Supermarket.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(11, ErrorMessage = "O campo TaxNumber deve conter pelo menos 11 dígitos")]
        [MaxLength(11, ErrorMessage = "O campo TaxNumber deve conter no máximo 11 dígitos")]
        public string TaxNumber { get; set; }


        public string Code { get; set; }

        [Required]
        public PositionEmployess Position { get; set; }

        [Required]
        public decimal Salary { get; set; }
        [Required]
        public DateTime DateOfAdmission { get; set; }
        
        public DateTime? DateOfDemission { get; set; }
    }

}
