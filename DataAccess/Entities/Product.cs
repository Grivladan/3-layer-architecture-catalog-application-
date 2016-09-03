using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Supplier> Suppliers { get; set; }

        public Product()
        {
            Suppliers=new List<Supplier>();
        }
    }
}
