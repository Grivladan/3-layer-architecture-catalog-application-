using System.Collections.Generic;
using System.Data.Entity;
using DataAccess.Entities;
using DataAccess.Entity_Framework;
using DataAccess.Interfaces;

namespace DataAccess.Repository
{
    public class SupplierRepository : IRepository<Supplier>
    {
        private readonly CatalogContext _context;

        public SupplierRepository(CatalogContext context)
        {
            _context = context;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _context.Suppliers.Include( p => p.Products );
        }

        public Supplier Get(int id)
        {
            return _context.Suppliers.Find(id);
        }

        public void Create(Supplier item)
        {
            _context.Suppliers.Add(item);
        }

        public void Update(Supplier item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Supplier supplier = _context.Suppliers.Find(id);
            if (supplier != null)
                _context.Suppliers.Remove(supplier);
        }
    }
}
