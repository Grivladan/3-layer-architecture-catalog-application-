using System.Collections.Generic;
using AutoMapper;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Logic.DTO;
using Logic.Infrastructure;
using Logic.Interfaces;

namespace Logic.Service
{
    class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork db;

        public CategoryService(IUnitOfWork uow)
        {
            db = uow;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Category, CategoryDto>());
            return Mapper.Map<IEnumerable<Category>, List<CategoryDto>>(db.Categories.GetAll());
        }

        public CategoryDto GetById(int id)
        {
            var category = db.Categories.Get(id);
            if (category == null)
                throw new ValidationException("Category doesn't exist", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Category, CategoryDto>());
            return Mapper.Map<Category, CategoryDto>(category);
        }

        public void Create(CategoryDto item)
        {
            var category = new Category()
            {
                Name = item.Name
            };

            db.Categories.Create(category);
            db.Save();
        }

        public void Update(int id, CategoryDto item)
        {
            var category = db.Categories.Get(id);
            if (category == null)
                return;

            category.Name = item.Name;

            db.Save();
        }

        public void Delete(int id)
        {
            db.Categories.Delete(id);
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
