using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace T2
{
    internal class Product
    {
         
        //test function
        public void list_all_products()
        {
            MySqlConnection MyConnection = null;
            MySqlDataReader MyReader = null;
             
            MyConnection = new MySqlConnection("Server=localhost; database=Store; UID=root; password=root");
            MyConnection.Open();
             
            MySqlCommand MyCommand = new MySqlCommand("SELECT * FROM PRODUCT", MyConnection);
            MyReader = MyCommand.ExecuteReader();
             
            MyReader.Close();
            MyConnection.Close();
            
             
        }
    }
}
