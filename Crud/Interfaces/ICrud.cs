namespace BlodBanken_Fabian_Henrik_Petrus;
using Dapper;
using MySqlConnector;
//INTERESTING
public interface ICrud<T>
{
    List<T> Read();
    int Create(T obj);
    void Update(T obj);
    void Delete(T obj);
}