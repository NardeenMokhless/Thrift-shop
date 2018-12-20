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
        [Column( IsPrimaryKey = true)] private int id;
        [Column] private string name;
        [Column] private float price;
        [Column] private string category;
        [Column] private int brand_id;

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

        public float Price
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
            get { return brand_id; }
            set { brand_id = value; }
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

        public void AddNewProduct(Product product, Store store)
        {
            store.Products.InsertOnSubmit(product);  
            store.SubmitChanges();
        }

        public void PrintProduct(Product product, Store store)
        {
            Console.Write("ID: " + product.Id); 
            Console.Write(", Name: " + product.Name); 
            Console.Write(", Price: " + product.Price); 
            Console.Write(", Category: " + product.Category); 
            
            Brand brand = new Brand();
            string brandName = brand.GetBrandName(product.BrandId, store);
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
