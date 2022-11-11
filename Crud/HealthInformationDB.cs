using System.Reflection.Metadata.Ecma335;
using BlodBanken_Fabian_Henrik_Petrus;
using MySqlConnector;
using Dapper;

class MyClass : ICrud<HealthInformation>
{
    public MySqlConnection DBConnection()
    {
        var connection = new MySqlConnection("Server=localhost;Database=blodbank;Uid=root;");
        return connection;
    }

    public List<HealthInformation> Read()
    {
        string query = "SELECT * FROM health_information";

        using (var connection = DBConnection())
        {
            try
            {
                var result = connection.Query<HealthInformation>(query).ToList();
                return result;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }

    public int Create(HealthInformation obj)
    {
        var parameters = new DynamicParameters(obj);

        string query =
            $"INSERT INTO health_information (donor_id, donor_height, donor_weight, is_drug_user, visited_high_risk_country) " +
            "VALUES(@donor_id, @donor_height, @donor_weight, @is_drug_user, @visited_high_risk_country); SELECT MAX(id) FROM blood_units;";

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

    public void Update(HealthInformation obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "UPDATE health_information " +
                       "SET donor_id = @donor_id, donor_height = @donor_height, donor_weight = @donor_weight, " +
                       "is_ = @appointment_date " +
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

    public void Delete(HealthInformation obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "DELETE health_information where id = @id";

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