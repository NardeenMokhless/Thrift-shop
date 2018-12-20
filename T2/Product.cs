using System;
using System.Collections.Generic;
using System.Data; 
using System.Data.Linq;
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
        [Column ( Name = "BrandID" )] private int brandID;
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

        public void AddNewProduct(Store store)
        {
            store.Products.InsertOnSubmit(this);  
            store.SubmitChanges();
        }

        public void PrintProduct(Store store)
        {
            Console.Write("ID: " + this.Id); 
            Console.Write(", Name: " + this.Name); 
            Console.Write(", Price: " + this.Price); 
            Console.Write(", Category: " + this.Category); 
            
            Brand brand = new Brand();
            string brandName = brand.GetBrandName(this.BrandId, store);
            Console.Write(", Brand name: " + brandName);
            Console.WriteLine();
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
