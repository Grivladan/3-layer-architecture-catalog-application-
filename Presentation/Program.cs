using DataAccess.Interfaces;
using DataAccess.Repository;
using Logic.Interfaces;
using Logic.Service;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "DbConnection";
            ISupplierService service = new SupplierService(connectionString);
            var suppliers = service.GetAll();
        }
    }
}
