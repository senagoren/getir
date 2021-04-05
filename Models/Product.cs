using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerWebApi.Models
{
    public class Product
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
