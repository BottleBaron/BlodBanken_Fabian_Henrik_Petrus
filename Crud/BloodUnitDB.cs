namespace BlodBanken_Fabian_Henrik_Petrus;
using Dapper;
using MySqlConnector;

class BloodUnitDB : ICrud<BloodUnit>
{
    public MySqlConnection DBConnection()
    {
        var connection = new MySqlConnection("Server=localhost;Database=blodbank;Uid=root;Pwd=samsis123");
        return connection;
    }

    public List<BloodUnit> Read()
    {
        string query = "SELECT * FROM blood_units";

        using (var connection = DBConnection())
        {
            try
            {
                var bloodUnits = connection.Query<BloodUnit>(query).ToList();

                return bloodUnits;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }

    public int Create(BloodUnit obj)
    {
        var parameters = new DynamicParameters(obj);
        
        string query = $"INSERT INTO blood_units (donor_id, booking_id, blood_type, is_consumed) " +
        "VALUES(@donor_id, @booking_id, @blood_type, @is_consumed); SELECT MAX(id) FROM blood_units;";

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

    public void Update(BloodUnit obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = $"UPDATE blood_units " +
        "SET donor_id = @donor_id, booking_id = @booking_id, blood_type = @blood_type, is_consumed = @is_consumed " +
        "WHERE id = @id";

        using (var connection = DBConnection())
        {
            try
            {
                connection.Execute(query);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }

    public void Delete(BloodUnit obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "DELETE blood_units WHERE id = @id";

        using (var connection = DBConnection())
        {
            try
            {
                connection.Execute(query);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}
