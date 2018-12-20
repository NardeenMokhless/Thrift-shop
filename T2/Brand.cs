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
        [Column] private string name;
        

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string BrandName
        {
            get { return name; }
            set { name = value; }
        }

        public int GetBrandID(string brandName, Store store)
        {
            foreach(Brand b in store.Brands)
                if (b.name == brandName)
                    return b.id;

            return -1;
        }
        public string GetBrandName(int brandId, Store store)
        {
            foreach(Brand b in store.Brands)
                if (b.id == brandId)
                    return b.name;

            return "no brand";
        }
        
        
        // return sorted array of brands according to number of product referencing to it 
//        public Tuple<Brand, int>[] get_Brands(Store store)
//        {
//            Tuple<Brand, int>[] brands_int = new Tuple<Brand, int>[];
//            
//        }
    }
}
