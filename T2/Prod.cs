using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace T2
{
    internal class Prod
    {
        private int id;
        private string name;
        private double price;
        private string category;
        private int brand_id;

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
            var prods = ds.GetTable<Prod>();
            
            IQueryable<Prod> products = from i in prods
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
                 
                Console.WriteLine(MyReader["id"]+" "+MyReader["name"]+" "+MyReader["price"]+" "+MyReader["category"]+" "+MyReader["Brand_id"]);
            }
        
            MyReader.Close();
            MyConnection.Close();
        }
        
    }
}
