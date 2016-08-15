using BDAvance.Models;

namespace BDAvance.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BDAvance.Models.CustomerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BDAvance.Models.CustomerDbContext context)
        {
            context.Products.AddOrUpdate(
                p=> p.ProductId,
                new Product() { ProductId = 1, Name = "Abricot"},
                new Product() { ProductId = 2, Name = "Banane" },
                new Product() { ProductId = 3, Name = "Cerise" },
                new Product() { ProductId = 4, Name = "Fraise" },
                new Product() { ProductId = 5, Name = "Kiwi" },
                new Product() { ProductId = 6, Name = "Framboise" },
                new Product() { ProductId = 7, Name = "Groseille" },
                new Product() { ProductId = 8, Name = "Prune" }
                );
            context.Customers.AddOrUpdate(
                c => c.CustomerId,
                new Customer() { CustomerId = 1, Name = "Albert"},
                new Customer() { CustomerId = 2 , Name = "Benoit"}
                );
        }
    }
}
