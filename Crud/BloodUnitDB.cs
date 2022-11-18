namespace BlodBanken_Fabian_Henrik_Petrus;
using Dapper;
using MySqlConnector;

internal class BloodUnitDB : DBConnection, ICrud<BloodUnit>
{
    public List<BloodUnit> Read()
    {
        string query = "SELECT id AS Id, donor_id AS DonorId, booking_id AS BookingId, blood_type AS BloodType,"+
         " is_consumed AS IsConsumed FROM blood_units";

        using (var connection = DBConnect())
        {
            try
            {
                var bloodUnits = connection.Query<BloodUnit>(query).ToList();

                return bloodUnits;
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

    public int Create(BloodUnit obj)
    {
        var parameters = new DynamicParameters(obj);
        
        string query = $"INSERT INTO blood_units (donor_id, booking_id, blood_type, is_consumed) " +
        "VALUES(@DonorId, @BookingId, @BloodType, @IsConsumed); SELECT MAX(id) FROM blood_units;";

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

    public void Update(BloodUnit obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = $"UPDATE blood_units " +
        "SET donor_id = @DonorId, booking_id = @BookingId, blood_type = @BloodType, is_consumed = @IsConsumed " +
        "WHERE id = @Id";

        using (var connection = DBConnect())
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

        string query = "DELETE blood_units WHERE id = @Id";

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
}
