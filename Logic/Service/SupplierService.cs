using System.Collections.Generic;
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
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork db;

        public SupplierService(IUnitOfWork uow)
        {
            db = uow;
        }

        public IEnumerable<SupplierDto> GetAll()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Supplier, SupplierDto>());
            return Mapper.Map<IEnumerable<Supplier>, List<SupplierDto>>(db.Suppliers.GetAll());
        }

        public SupplierDto GetById(int id)
        {
            var supplier = db.Suppliers.Get(id);
            if (supplier == null)
                throw new ValidationException("Supplier doesn't exist", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Supplier, SupplierDto>());
            return Mapper.Map<Supplier, SupplierDto>(supplier);
        }

        public IEnumerable<SupplierDto> GetSuppliersByCategory(Category category)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Supplier, SupplierDto>());
            return Mapper.Map<IEnumerable<Supplier>, List<SupplierDto>>(db.Suppliers.GetAll().Where(x => x.Products.Any(p => p.Category == category)));
        }

        public void Create(SupplierDto item)
        {
            var supplier = new Supplier()
            {
                Name = item.Name,
                City = item.City
            };

            db.Suppliers.Create(supplier);
            db.Save();
        }

        public void Update(int id, SupplierDto item)
        {
            var supplier = db.Suppliers.Get(id);
            if (supplier == null)
                return;

            supplier.Name = item.Name;
            supplier.City = item.City;

            db.Save();
        }

        public void Delete(int id)
        {
            db.Suppliers.Delete(id);
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}