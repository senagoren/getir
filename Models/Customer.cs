using System.ComponentModel.DataAnnotations;

namespace CustomerWebApi.Models
{
    public class Customer
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}
