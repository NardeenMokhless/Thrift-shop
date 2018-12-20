using MySql.Data.MySqlClient;

namespace T2
{
    internal class Product
    {
        private int id;
        private string name;
        private string category;
        private double price;
        private int brand_id;
       
        //test function
        public void getAllProductsFromDB()
        {
            MySqlConnection MyConnection = null;
           // MySqlDataReader MyReader = null;
             
            MyConnection = new MySqlConnection("Server=localhost; database=Store; UID=root; password=root");
            MyConnection.Open();
             
            /*
            MySqlCommand MyCommand = new MySqlCommand("SELECT * FROM PRODUCT", MyConnection);
            MyReader = MyCommand.ExecuteReader();

            while (MyReader.Read())
            {
                 
                Console.WriteLine(MyReader["id"]+" "+MyReader["name"]+" "+MyReader["price"]+" "+MyReader["category"]+" "+MyReader["Brand_id"]);
            }*/
            MySqlCommand mySqlCommand = new MySqlCommand();
            MySqlDataReader mySqlDataReader = null;
            //var name = from prod in Product.; 
            
            //var students = mySqlDataReader.Query<Product>("SELECT * FROM PRODUCT").ToList();
            
            //MyReader.Close();
            MyConnection.Close();
        }
        
    }
}
