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
//            for (int i = 0; i < 10; i++)
//            {
//                product = new Product();
//                product.Id = i;
//                product.Name = "Name" + i;
//                product.Price = 30.0;
//                product.Category = "Categorey" + i;
//                product.BrandId = i % 4 + 1;
//                product.AddNewProduct(store);
//            }

            IEnumerable<Product> products = product.GetAllProducts(store);
            foreach (var pro in products)
            {
                pro.PrintProduct(store);
            }
        }
    }
}

