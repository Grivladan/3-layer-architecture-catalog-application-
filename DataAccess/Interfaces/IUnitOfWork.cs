using System;
using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<Product> Products { get; }
        IRepository<Supplier> Suppliers { get; }
        void Save();
    }
}
