using System;
using Microsoft.EntityFrameworkCore;
namespace CustomerWebApi.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
