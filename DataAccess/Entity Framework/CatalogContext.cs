using System.Data.Entity;
using DataAccess.Entities;

namespace DataAccess.Entity_Framework
{
    public class CatalogContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public CatalogContext(string connectionString)
            : base(connectionString)
        {
            base.Configuration.ProxyCreationEnabled = true;
            base.Configuration.LazyLoadingEnabled = true;
        }
    }
}
