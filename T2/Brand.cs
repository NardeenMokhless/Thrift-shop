using System;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
 
namespace T2
{
    [Table( Name = "Brand" )]
    public class Brand
    {
        [Column( IsPrimaryKey = true)] private int id;
        [Column] private string brandName;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string BrandName
        {
            get { return brandName; }
            set { brandName = value; }
        }

        public string GetBrandName(int brandId, Store store)
        {
            foreach(Brand b in store.Brands)
                if (b.id == brandId)
                    return b.brandName;

            return "no brand";
        }
    }
}
