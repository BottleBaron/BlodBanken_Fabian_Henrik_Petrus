namespace BlodBanken_Fabian_Henrik_Petrus;
using Dapper;
using MySqlConnector;

public interface ICrud<T>
{
    public MySqlConnection DBConnection()
    {
        var connection = new MySqlConnection("Server=localhost;Database=blodbank;Uid=root;");
        return connection;
    }
    List<T> Read();
    int Create(T obj);
    void Update(T obj);
    void Delete(T obj);
}