using System;
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

        public void print_brand_by_number_refereceing(Store store)
        {
            var query =
                from product in store.Products
                group product by product.brandID
                into grouped
                orderby grouped.Count()
                select grouped;

//            ;
            foreach (var v in query.OrderByDescending(x => x.Count()))
            {
                Console.WriteLine(GetBrandName(v.Key,store) + " - " + v.Count());
            }
        }
        
    }
}
