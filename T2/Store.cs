using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace T2
{
    [Database(Name = "Store")]
    public class Store : DataContext
    {
        public Table<Product> Products;
        public Table<Brand> Brands;
        
        public Store() : base("Server=.;Database=store;Trusted_Connection=True;")
        {
        }

        public Store(string fileOrServerOrConnection, MappingSource mapping) : base(fileOrServerOrConnection, mapping)
        {
        }

        public Store(IDbConnection connection) : base(connection)
        {
        }

        public Store(IDbConnection connection, MappingSource mapping) : base(connection, mapping)
        {
        }
    }
}
