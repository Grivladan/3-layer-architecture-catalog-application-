using System.Collections.Generic;
using DataAccess.Entities;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<SupplierDto> GetAll();
        SupplierDto GetById(int id);
        IEnumerable<SupplierDto> GetSuppliersByCategory(Category category);
        void Create(SupplierDto item);
        void Update(int id, SupplierDto item);
        void Delete(int id);
        void Dispose();
    }
}
