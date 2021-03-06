﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Repository;
using Logic.DTO;
using Logic.Infrastructure;
using Logic.Interfaces;

namespace Logic.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork db;

        public ProductService(IUnitOfWork uow)
        {
            db = uow;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDto>());
            return Mapper.Map<IEnumerable<Product>, List<ProductDto>>(db.Products.GetAll());
        }

        public ProductDto GetById(int id)
        {
            var product = db.Products.Get(id);
            if (product == null)
                throw new ValidationException("Product doesn't exist", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDto>());
            return Mapper.Map<Product, ProductDto>(product);
        }

        public void Create(ProductDto item)
        {
            var product = new Product()
            {
                Name=item.Name,
                Price = item.Price
            };

            db.Products.Create(product);
            db.Save();
        }

        public void Update(int id, ProductDto item)
        {
            var product = db.Products.Get(id);
            if (product == null)
                return;

            product.Name = item.Name;
            product.Price = item.Price;

            db.Save();
        }

        public void Delete(int id)
        {
            db.Products.Delete(id);
            db.Save();
        }

        public IEnumerable<ProductDto> GetByCategory(Category category)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDto>());
            return Mapper.Map<IEnumerable<Product>, List<ProductDto>>(db.Products.GetAll().Where(x => x.Category.Name == category.Name));
            return  Mapper.Map<IEnumerable<Product>, List<ProductDto>>(db.Products.GetAll().Where(x => x.Category.Name == category.Name));
        }

        public IEnumerable<ProductDto> GetBySupplier(Supplier supplier)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDto>());
            return Mapper.Map<IEnumerable<Product>, List<ProductDto>>(db.Products.GetAll().Where(x => x.Suppliers.Contains(supplier)));
        }

        public IEnumerable<ProductDto> GetByUserCondition(Func<Product, bool> predicate )
        {
            var products = db.Products.GetAll().Where(predicate);
            if (products == null)
                throw new ValidationException("Products doesn't exist", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDto>());
            return Mapper.Map<IEnumerable<Product>, List<ProductDto>>(products);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
