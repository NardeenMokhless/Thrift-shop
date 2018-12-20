using System;
using System.Collections.Generic;
using System.Linq;

namespace T2
{
    internal class Menu
    {
        public static void Main(string[] args)
        {
            Store store = new Store();
            Product product = new Product();

            IEnumerable<Product> products = product.GetAllProducts(store);
            for(int i = 0; i < products.Count(); i++) 
            {
                Product p1 = products.ElementAt(i);
                p1.PrintProduct(store);
                  
            }
            Console.WriteLine();

            IEnumerable<Product> products1 = product.GetProductsLessThanSPrice(store, 50);
            for(int i = 0; i < products1.Count(); i++) 
            {
                Product p1 = products1.ElementAt(i);
                p1.PrintProduct(store);
                  
            }

            
        }
    }
}

