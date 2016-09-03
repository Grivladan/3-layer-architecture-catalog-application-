using System.Collections.Generic;
using Logic.DTO;

namespace Logic.Interfaces
{
    interface ISupplierService
    {
        IEnumerable<SupplierDto> GetAll();
        SupplierDto GetById(int id);
        IEnumerable<SupplierDto> GetSuppliersByCategory();
    }
}
