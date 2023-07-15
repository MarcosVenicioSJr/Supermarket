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
        public PositionEmployess Position { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public DateTime DateOfAdmission { get; set; }
        public DateTime DateOfDemission { get; set; }
    }
}
