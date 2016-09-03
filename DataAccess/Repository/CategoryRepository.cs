using System.Collections.Generic;
using System.Data.Entity;
using DataAccess.Entities;
using DataAccess.Entity_Framework;
using DataAccess.Interfaces;

namespace DataAccess.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly CatalogContext _context;

        public CategoryRepository(CatalogContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.Include(p => p.Products);
        }

        public Category Get(int id)
        {
            return _context.Categories.Find(id);
        }

        public void Create(Category item)
        {
            _context.Categories.Add(item);
        }

        public void Update(Category item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Category category=_context.Categories.Find(id);
            if (category != null)
                _context.Categories.Remove(category);
        }
    }
}
