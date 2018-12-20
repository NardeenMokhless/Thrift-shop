using System;
 
namespace T2
{
    internal class Menu
    {
        public static void Main(string[] args)
        {
            Store store = new Store();
            Console.WriteLine("DB connected successful");
            foreach( Product p in store.Products)
            {
                string title = p.Name;
                Console.WriteLine(title);
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
