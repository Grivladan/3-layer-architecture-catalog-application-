using System.Collections.Generic;
using DataAccess.Entities;
using Logic.DTO;

namespace Logic.Interfaces
{
    interface IProductService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto GetById(int id);
        void Create(ProductDto item);
        void Update(int id, ProductDto item);
        void Delete(int id);
        IEnumerable<ProductDto> GetByCategory(Category category);
        IEnumerable<ProductDto> GetBySupplier(Supplier supplier);
        IEnumerable<ProductDto> GetByUserCondition();
        void Dispose();
    }

}
