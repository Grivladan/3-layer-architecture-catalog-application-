using System;
using DataAccess.Entities;
using DataAccess.Entity_Framework;
using DataAccess.Interfaces;

namespace DataAccess.Repository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private CatalogContext db;
        private ProductRepository productRepository;
        private SupplierRepository supplierRepository;
        private CategoryRepository categoryRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new CatalogContext(connectionString);
        }

        public IRepository<Category> Categories
        {
            get
            {
                if(categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                if(productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }

        public IRepository<Supplier> Suppliers
        {
            get
            {
                if(supplierRepository == null)
                    supplierRepository = new SupplierRepository(db);
                return supplierRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
