namespace BlodBanken_Fabian_Henrik_Petrus;
using Dapper;
using MySqlConnector;

internal class StaffDB : DBConnection, ICrud<Staff>
{
    public List<Staff> Read()
    {
        string query = "SELECT id AS Id, login_name AS LoginName, name AS Name, password as Password FROM staff";

        using (var connection = DBConnect())
        {
            try
            {
                var result = connection.Query<Staff>(query).ToList();
                return result;
            }
            catch (System.InvalidOperationException)
            {
                return null;
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
                       "VALUES(@Name, LoginName, Password); SELECT MAX(id) FROM bookings";

        using (var connection = DBConnect())
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
                       "SET name = @Name, login_name = @LoginName, password = @Password" +
                       "WHERE id = @Id";

        using (var connection = DBConnect())
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

        string query = "DELETE staff where id = @Id";

        using (var connection = DBConnect())
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
    
    public Staff SelectStaff(int id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        string query = "SELECT * FROM staff WHERE id = @Id";

        using (var connection = DBConnect())
        {
            try
            {
                Staff result = connection.QuerySingle<Staff>(query, parameters);
                return result;
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

    }
}
