using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Supplier()
        {
            Products=new List<Product>();
        }
    }
}
