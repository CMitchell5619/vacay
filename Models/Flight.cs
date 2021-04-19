using System;
using System.ComponentModel.DataAnnotations;

namespace vacay.Models
{
    public class Flight : Vacation
    {
        public int? Layovers { get; set; }
        public int flightId { get; set; }

        public Flight()
        {
            Category = "Flight";
        }


    }
}