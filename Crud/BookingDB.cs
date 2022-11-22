namespace BlodBanken_Fabian_Henrik_Petrus;
using Dapper;
using MySqlConnector;

internal class BookingDB :DBConnection, ICrud<Booking>
{
    public List<Booking> Read()
    {
        string query = "SELECT id AS Id, donor_id AS DonorId, staff_id AS StaffId,"+ 
        " appointment_date AS AppointmentDate, is_done AS IsDone"+
        " FROM bookings";

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
        "VALUES(@DonorId, @StaffId, @IsDone, @AppointmentDate); SELECT MAX(id) FROM bookings;";


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
        "SET donor_id = @DonorId, staff_id = @StaffId, is_done = @IsDone, appointment_date = @AppointmentDate " +
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

    public void Delete(Booking obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "DELETE bookings WHERE id = @Id";

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

        string query = "SELECT id AS Id, donor_id AS DonorId, staff_id AS StaffId,"+ 
        " appointment_date AS AppointmentDate, is_done AS IsDone"+ " FROM bookings WHERE staff_id = @Id";

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

    public void DeleteBooking(Booking obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "DELETE FROM bookings WHERE donor_id = @id";

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



     public Booking SelectByBookingId(int id)
    {
       
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        string query = "SELECT id AS Id, donor_id AS DonorId, staff_id AS StaffId,"+ 
        " appointment_date AS AppointmentDate, is_done AS IsDone"+ " FROM bookings WHERE id = @Id";

        using (var connection = DBConnect())
        {
            try
            {
                Booking booking = connection.QuerySingle<Booking>(query, parameters);
                return booking;
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