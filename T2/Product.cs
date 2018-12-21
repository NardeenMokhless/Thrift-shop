using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;

namespace T2
{
    [Table( Name = "Product" )]
    public class Product
    {
        [Column( Name = "ID", IsPrimaryKey = true)] private int id;
        [Column ( Name = "NAME" )] private string name;
        [Column ( Name = "PRICE" )] private double price;
        [Column ( Name = "CATEGORY" )] private string category;
        [Column ( Name = "BrandID" )] public int brandID;

        public Product()
        {
        }
        public Product(int id, string name, double price, string category)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.category = category;
        }
        public Product(int id, string name, double price, string category, int brandId)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.category = category;
            brandID = brandId;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public int BrandId
        {
            get { return brandID; }
            set { brandID = value; }
        }
        public bool CheckID(int id, Store store)
        {
            foreach(Product p in store.Products)
                if (p.id == id)
                    return true;

            return false;
        }
        public IEnumerable<Product> GetAllProducts(Store store)
        {
            IEnumerable<Product> products = from product in store.Products
                                                select product;

            return products;
        }
        public IEnumerable<Product> GetProductsLessThanSPrice(Store store, double price)
        {
            IEnumerable<Product> products = from product in store.Products
                                            where product.price.CompareTo(price) <= 0
                                              select product;

            return products;
        }

        public int AddNewProduct(string brandName, Store store)
        {
            if (CheckID(this.id, store))
                return 0;
            
            Brand brand = new Brand();
            int brandId = brand.GetBrandID(brandName, store);
            if (brandId == -1)  
                return -1;
            this.BrandId = brandId;
            store.Products.InsertOnSubmit(this);  
            store.SubmitChanges();
            return 1;
        }

        public void PrintProduct(Store store)
        {
            Console.Write("ID: " + this.Id); 
            Console.Write(", Name: " + this.Name); 
            Console.Write(", Price: " + this.Price); 
            Console.Write(", Category: " + this.Category);
            Console.Write(", BrandID: " + this.BrandId);
            
            Brand brand = new Brand();
            string brandName = brand.GetBrandName(this.BrandId, store);
            Console.Write(", Brand name: " + brandName);
            Console.WriteLine();
        }

        public void print_product_sorted_according_name(Store store, Boolean desc = false)
        {
            var query =
                from product in store.Products
                orderby product.name
                select product;
            var q1 = query;
            if (desc)
                q1 = query.OrderByDescending(x => x.name);
            foreach (var v in q1)
            {
                v.PrintProduct(store);                
            }
        }
        public void print_product_sorted_according_price(Store store, Boolean desc = false)
        {
            var query =
                from product in store.Products
                orderby product.price
                select product;
            var q1 = query;
            if (desc)
                q1 = query.OrderByDescending(x => x.price);
            foreach (var v in q1)
            {
                v.PrintProduct(store);                
            }
        }


        /*
        public void test()
        {
            var dbConnection = DBConnection.Instance();
            string dbConnectionString =
                string.Format("Server=localhost; database=Store; UID=root; password=root");
            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);
            conn.Open();
            IDbConnection co = conn;
            MappingSource mappingSource = new AttributeMappingSource();

            DataContext ds = new DataContext(co, mappingSource);
            var prods = ds.GetTable<Product>();

            IQueryable<Product> products = from i in prods
                select i;

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(products.GetEnumerator().ToString());
            }
        }

        //test function
        public void getAllProductsFromDB()
        {
            MySqlConnection MyConnection = null;
            MySqlDataReader MyReader = null;

            MyConnection = new MySqlConnection("Server=localhost; database=Store; UID=root; password=root");
            MyConnection.Open();


            MySqlCommand MyCommand = new MySqlCommand("SELECT * FROM PRODUCT", MyConnection);
            MyReader = MyCommand.ExecuteReader();

            while (MyReader.Read())
            {

                Console.WriteLine(MyReader["id"] + " " + MyReader["name"] + " " + MyReader["price"] + " " +
                                  MyReader["category"] + " " + MyReader["Brand_id"]);
            }

            MyReader.Close();
            MyConnection.Close();
        }*/
    }

}
