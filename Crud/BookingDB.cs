namespace BlodBanken_Fabian_Henrik_Petrus;
using Dapper;
using MySqlConnector;

internal class BookingDB :DBConnection, ICrud<Booking>
{
    public List<Booking> Read()
    {
        string query = "SELECT * FROM bookings";

        using (var connection = DBConnect())
        {
            try
            {
                var result = connection.Query<Booking>(query).ToList();
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

    public int Create(Booking obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "INSERT INTO bookings (donor_id, staff_id, is_done, appointment_date) " +
        "VALUES(@donor_id, @staff_id, @is_done, @appointment_date); SELECT MAX(id) FROM bookings";

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


    public void Update(Booking obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "UPDATE bookings " +
        "SET donor_id = @donor_id, staff_id = @staff_id, is_done = @is_done, appointment_date = @appointment_date " +
        "WHERE id = @id";

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

    public void Delete(Booking obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "DELETE bookings WHERE id = @id";

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

    public List<Booking> SelectByStaffId(Staff obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "SELECT * FROM bookings WHERE staff_id = @id";

        using (var connection = DBConnect())
        {
            try
            {
                var result = connection.Query<Booking>(query, parameters).ToList();
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