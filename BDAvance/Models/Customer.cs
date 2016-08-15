using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDAvance.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }


    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductQuantity> ProductQuantities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public CustomerDbContext()
            : base("DefaultConnection")
        {
        }

        public static CustomerDbContext Create()
        {
            return new CustomerDbContext();
        }
    }
}
