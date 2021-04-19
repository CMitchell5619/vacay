using System.ComponentModel.DataAnnotations;

namespace vacay.Models
{
    //NOTE removed abstract to properly return in repository
    public class Vacation
    {
        public int Id { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public string Category { get; set; }
    }
}