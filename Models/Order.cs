using System.ComponentModel.DataAnnotations;
using static CustomerWebApi.Models.Enumerations;
namespace CustomerWebApi.Models
{
    public class Order
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public long CustomerId { get; set; }

        [Required]
        public long ProductId { get; set; }

        [Required]
        public OrderStatus Status { get; set; }
    }
}
