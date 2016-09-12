using System;
using DataAccess.Interfaces;
using DataAccess.Repository;
using Logic.Interfaces;
using Logic.Service;
using DataAccess.Entities;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "DbConnection";
            ISupplierService supplierService = new SupplierService(new EFUnitOfWork(connectionString));
            ICategoryService categoryService = new CategoryService(new EFUnitOfWork(connectionString));
            IProductService productService = new ProductService(new EFUnitOfWork(connectionString));
            var products = productService.GetAll();
            foreach(var item in products)
                Console.WriteLine(item.Name +" "+ item.Price);
            Category category = new Category {Id=1, Name="Category1"};
            var productsByCategory = productService.GetByCategory(category);
            foreach(var item in productsByCategory)
                Console.WriteLine(item.Name+" "+item.Price);
        }
    }
}
