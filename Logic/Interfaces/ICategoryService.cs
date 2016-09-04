using System.Collections.Generic;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAll();
        CategoryDto GetById(int id);
        void Create(CategoryDto item);
        void Update(int id, CategoryDto item);
        void Delete(int id);
        void Dispose();
    }
}
