namespace BlodBanken_Fabian_Henrik_Petrus;
using Dapper;
using MySqlConnector;

class BloodUnitDB
{
    private static MySqlConnection DBConnection()
    {
        var connection = new MySqlConnection("Server=localhost;Database=blodbank;Uid=root;");
        return connection;
    }

    // SELECT CREATE DELETE UPDATE
    public static List<BloodUnit> Select()
    {
        string query = "SELECT * FROM blood_units";

        using (var Connection = DBConnection())
        {
            try
            {
                var bloodUnits = Connection.Query<BloodUnit>(query).ToList();

                return bloodUnits;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }

    public static void Create(BloodUnit bloodUnit)
    {
        var parameters = new DynamicParameters(bloodUnit);
        
        string query = $"INSERT INTO blood_units (donor_id, booking_id, blood_type, is_consumed) VALUES(@donor_id, @booking_id, @blood_type, @is_consumed)";

        using (var Connection = DBConnection())
        {
            try
            {
                Connection.Execute(query, parameters);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }

    public static void Update(BloodUnit bloodUnit)
    {
        var parameters = new DynamicParameters();
        

        string query = $"UPDATE blood_units SET 'parameters' WHERE 'condition' ";

        using (var Connection = DBConnection())
        {
            try
            {
                Connection.Execute(query);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}
