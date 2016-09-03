using System.Collections.Generic;
using System.Data.Entity;
using DataAccess.Entities;
using DataAccess.Entity_Framework;
using DataAccess.Interfaces;

namespace DataAccess.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly CatalogContext _context;

        public ProductRepository(CatalogContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }

        public void Create(Product item)
        {
             _context.Products.Add(item);
        }

        public void Update(Product item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
             Product product=_context.Products.Find(id);
            if (product != null)
                _context.Products.Remove(product);
        }
    }
}
