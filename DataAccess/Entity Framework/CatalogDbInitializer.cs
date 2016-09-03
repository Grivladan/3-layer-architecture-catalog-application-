using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataAccess.Entity_Framework
{
    class CatalogDbInitializer : DropCreateDatabaseAlways<CatalogContext>
    {
        protected override void Seed(CatalogContext db)
        {
            
        }
    }
}
