namespace BlodBanken_Fabian_Henrik_Petrus;
using Dapper;
using MySqlConnector;

public interface ICrud<T>
{
    MySqlConnection DBConnection();
    List<T> Read();
    int Create(T obj);
    void Update(T obj);
    void Delete(T obj);
}