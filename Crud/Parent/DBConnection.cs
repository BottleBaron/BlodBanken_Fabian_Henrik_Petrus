namespace BlodBanken_Fabian_Henrik_Petrus;
using Dapper;
using MySqlConnector;

class DBConnection
{
      //Parent class that handles the server and user/pw for the database connection
      public MySqlConnection DBConnect()
    {
         var connection = new MySqlConnection("Server=localhost;Database=blodbank;Uid=root;");
        return connection;
    }
}