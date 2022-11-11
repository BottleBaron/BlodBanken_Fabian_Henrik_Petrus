namespace BlodBanken_Fabian_Henrik_Petrus;
using Dapper;
using MySqlConnector;

public class StaffDB : ICrud<Staff>
{
    public MySqlConnection DBConnection()
    {
        var connection = new MySqlConnection("Server=localhost;Database=blodbank;Uid=root;");
        return connection;
    }

    public List<Staff> Read()
    {
        string query = "SELECT * FROM staff";

        using (var connection = DBConnection())
        {
            try
            {
                var result = connection.Query<Staff>(query).ToList();
                return result;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }

    public int Create(Staff obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "INSERT INTO staff (name, login_name, password) " +
                       "VALUES(@name, login_name, password); SELECT MAX(id) FROM bookings";

        using (var connection = DBConnection())
        {
            try
            {
                var identity = connection.ExecuteScalar<int>(query, parameters);
                return identity;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }    
    }

    public void Update(Staff obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "UPDATE staff " +
                       "SET name = @name, login_name = @login_name, password = @password" +
                       "WHERE id = @id";

        using (var connection = DBConnection())
        {
            try
            {
                connection.Execute(query, parameters);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }

    public void Delete(Staff obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "DELETE staff where id = @id";

        using (var connection = DBConnection())
        {
            try
            {
                connection.Execute(query, parameters);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

    }
}
