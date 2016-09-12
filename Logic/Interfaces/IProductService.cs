using System;
using System.Collections.Generic;
using DataAccess.Entities;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto GetById(int id);
        void Create(ProductDto item);
        void Update(int id, ProductDto item);
        void Delete(int id);
        IEnumerable<ProductDto> GetByCategory(Category category);
        IEnumerable<ProductDto> GetBySupplier(Supplier supplier);
        IEnumerable<ProductDto> GetByUserCondition(Func<Product, bool> predicate);
        void Dispose();
    }

}
