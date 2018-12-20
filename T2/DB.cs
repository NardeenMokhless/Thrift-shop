using System;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace T2
{
     public class DBConnection
     {
          private DBConnection()
          {
          }

          public string get_database_config()
          {
               return string.Format("Server=localhost; database=Store; UID=root; password=root", databaseName);
          }

          private string databaseName = string.Empty;
          public string DatabaseName
          {
               get { return databaseName; }
               set { databaseName = value; }
          }

          private MySqlConnection connection = null;
          public MySqlConnection Connection
          {
               get { return connection; }
          }

          private static DBConnection _instance = null;
          public static DBConnection Instance()
          {
               if (_instance == null)
                    _instance = new DBConnection();
               return _instance;
          }

          public bool IsConnect()
          {
               if (Connection == null)
               {
                    if (String.IsNullOrEmpty(databaseName))
                         return false;
                    string connstring = get_database_config();
                    connection = new MySqlConnection(connstring);
                    connection.Open();
               }

               return true;
          }

          public void Close()
          {
               connection.Close();
          }

          /*
          public void createTables()
          {
               string dbConnectionString = get_database_config();
               var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);
               conn.Open();
               string createTableQuery1 = "CREATE TABLE Brand (id INT PRIMARY KEY,BrandName VARCHAR(100));";
               var cmd1 = new MySql.Data.MySqlClient.MySqlCommand(createTableQuery1, conn);
               cmd1.ExecuteNonQuery();
               string createTableQuery2 = "CREATE TABLE Product(Id Int PRIMARY KEY, Name VARCHAR(100)," +
                                          "Price Double,Category VARCHAR(100), Brand_id Int, FOREIGN KEY (Brand_id) REFERENCES Brand(id));";
               var cmd2 = new MySql.Data.MySqlClient.MySqlCommand(createTableQuery2, conn);
               cmd2.ExecuteNonQuery();  
          }*/
     }
}
