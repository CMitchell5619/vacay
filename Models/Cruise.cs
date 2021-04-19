
namespace vacay.Models
{
    public class Cruise : Vacation
    {
        public int? Ports { get; set; }
        public int Id { get; set; }

        public Cruise()
        {
            Category = "Drink";
        }

    }
}