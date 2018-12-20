using System;
using MySql.Data.MySqlClient;

namespace T2
{
    internal class Menu
    {
        public static void Main(string[] args)
        {
            
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "Store";
            
            if (dbCon.IsConnect())
            {   
                 
                Prod b = new Prod();
                b.test();
                
                Console.WriteLine("DB connected successful");
                dbCon.Close();
            }
        }
    }
}
