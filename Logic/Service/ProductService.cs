using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repository;
using Logic.DTO;
using Logic.Infrastructure;
using Logic.Interfaces;

namespace Logic.Service
{
    class ProductService : IProductService
    {
        private readonly ProductRepository _repository;

        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDto>());
            return Mapper.Map<IEnumerable<Product>, List<ProductDto>>(_repository.GetAll());
        }

        public ProductDto GetById(int id)
        {
            var product = _repository.Get(id);
            if (product == null)
                throw new ValidationException("Product doesn't exist", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDto>());
            return Mapper.Map<Product, ProductDto>(product);
        }

        public IEnumerable<ProductDto> GetByCategory(Category category)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDto>());
            return Mapper.Map<IEnumerable<Product>, List<ProductDto>>(_repository.GetAll().Where(x=>x.CategoryId == category.Id));
        }

        public IEnumerable<ProductDto> GetBySupplier(Supplier supplier)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductDto> GetByUserCondition()
        {
            throw new System.NotImplementedException();
        }
    }
}
