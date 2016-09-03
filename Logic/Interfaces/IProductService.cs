using System.Collections.Generic;
using DataAccess.Entities;
using Logic.DTO;

namespace Logic.Interfaces
{
    interface IProductService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto GetById(int id);
        IEnumerable<ProductDto> GetByCategory(Category category);
        IEnumerable<ProductDto> GetBySupplier(Supplier supplier);
        IEnumerable<ProductDto> GetByUserCondition();
    }

}
