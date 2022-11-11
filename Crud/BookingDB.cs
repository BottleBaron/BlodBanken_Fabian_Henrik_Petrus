namespace BlodBanken_Fabian_Henrik_Petrus;
using Dapper;
using MySqlConnector;

class BookingDB : ICrud<Booking>
{
    public MySqlConnection DBConnection()
    {
        var connection = new MySqlConnection("Server=localhost;Database=blodbank;Uid=root;");
        return connection;
    }

    // READ CREATE DELETE UPDATE
    public List<Booking> Read()
    {
        string query = "SELECT * FROM bookings";

        using (var connection = DBConnection())
        {
            try
            {
                var result = connection.Query<Booking>(query).ToList();
                return result;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }

    public int Create(Booking obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "INSERT INTO bookings (donor_id, staff_id, is_done, appointment_date) " +
        "VALUES(@donor_id, @staff_id, @is_done, @appointment_date); SELECT MAX(id) FROM bookings";

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


    public void Update(Booking obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "UPDATE bookings " +
        "SET donor_id = @donor_id, staff_id = @staff_id, is_done = @is_done, appointment_date = @appointment_date " +
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

    public void Delete(Booking obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "DELETE bookings where id = @id";

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