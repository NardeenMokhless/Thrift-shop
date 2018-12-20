using System;
using System.Collections.Generic;
using System.Linq;

namespace T2
{
    public class Menu
    {
        public static void ShowProducts(Store store, Product product)
        {
            IEnumerable<Product> products = product.GetAllProducts(store);
            for(int i = 0; i < products.Count(); i++) 
            {
                Product p1 = products.ElementAt(i);
                p1.PrintProduct(store);
                  
            }
            Console.WriteLine();
        }

        public static void AddNewProducts(Store store, Product product)
        {
            Console.WriteLine("Enter product id:");
            int product_id = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Enter product name:");
            string product_name = Console.ReadLine();

            Console.WriteLine("Enter product price:");
            int product_price = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter product category:");
            string product_category = Console.ReadLine();
            
            Console.WriteLine("Enter brand name:");
            string brand_name = Console.ReadLine();
            
            Product p = new Product(product_id, product_name, product_price, product_category);
            int check = p.AddNewProduct(brand_name, store);
            if(check == 1)
                Console.WriteLine("Product is added successfully");
            else if(check == -1)
                Console.WriteLine("This brand does not exist !!!");
            if(check == 0)
                Console.WriteLine("Product id already exists !!!");
        }

        public static void GetProductsLessThanSPrice(Store store, Product product)
        {
            Console.WriteLine("Enter a price number:");
            int price = Convert.ToInt32(Console.ReadLine());
            
            IEnumerable<Product> products1 = product.GetProductsLessThanSPrice(store, price);
            for(int i = 0; i < products1.Count(); i++) 
            {
                Product p1 = products1.ElementAt(i);
                p1.PrintProduct(store);
                  
            }
            
        }

        public static void MainMenu(Store store, Product product, Brand brand)
        {
            Console.WriteLine("<List of Actions>\n1.Show Products\n2.Add New Product\n3.Filter Products By Price\n4.Show Brands\n5.Sort Product");
            Console.WriteLine("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
                ShowProducts(store, product);
            else if (choice == 2)
                AddNewProducts(store, product);
            else if (choice == 3)
                GetProductsLessThanSPrice(store, product);
            
            MainMenu(store, product, brand);
        }
        public static void Main(string[] args)
        {
            Store store = new Store();
            Product product = new Product();
            Brand brand = new Brand();
            MainMenu(store, product, brand);
        }
    }
}

