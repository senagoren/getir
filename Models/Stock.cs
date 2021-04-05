using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerWebApi.Models
{
    public class Stock
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public long ProductId { get; set; }

        public int NumberOfProduct { get; set; }
    }
}
