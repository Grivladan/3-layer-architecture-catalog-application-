using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataAccess.Entity_Framework
{
    class CatalogDbInitializer : DropCreateDatabaseAlways<CatalogContext>
    {
        protected override void Seed(CatalogContext db)
        {
            Product product1 = new Product { Id = 1, Name = "Product1", Price = 25, Category = new Category { Id=1, Name="Category1"} };
            Product product2 = new Product { Id = 2, Name = "Product2", Price = 30, Category = new Category { Id=2, Name="Category2"} };
            db.Products.Add(product1);
            db.Products.Add(product2);
            base.Seed(db);
        }
    }
}
