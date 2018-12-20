using System;
using System.Collections.Generic;

namespace T2
{
    internal class Menu
    {
        public static void Main(string[] args)
        {
            Store store = new Store();
            Product product = new Product();
            Console.WriteLine("DB connected successful");
            foreach(Product p in store.Products)
            {
                var title = p.Name;
                Console.WriteLine(title);
            }

            IEnumerable<Product> products = product.GetAllProducts(store);
            /*for (int i = 0; i < 2; i++)
            {
                
            }
            /*
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "Store";
            
            if (dbCon.IsConnect())
            {   
                 
                
                
                Console.WriteLine("DB connected successful");
                dbCon.Close();
            }*/
        }
    }
}
