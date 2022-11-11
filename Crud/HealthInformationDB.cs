using System.Reflection.Metadata.Ecma335;
using BlodBanken_Fabian_Henrik_Petrus;
using MySqlConnector;
using Dapper;
class HealthInformationDB : ICrud<HealthInformation>
{

   

    public int Create(HealthInformation healthInformation)
    {
         var parameters = new DynamicParameters(healthInformation);
        
        string query = $"INSERT INTO health_information (donor_id, donor_height, donor_weight, is_drug_user, visited_high_risk_country) " +
        "VALUES(@donor_id, @donor_height, @donor_weight, @is_drug_user, @visited_high_risk_country); SELECT LAST_INSERT_ID();";

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

    public MySqlConnection DBConnection()
    {
         var connection = new MySqlConnection("Server=localhost;Database=blodbank;Uid=root;");
        return connection;
    }

    public void Delete(HealthInformation healthInformation)
    {
         var parameters = new DynamicParameters(healthInformation);

        string query = "DELETE health_information WHERE id = @id";

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
    

    public List<HealthInformation> Read()
    {
        throw new NotImplementedException();
    }

    public void Update(HealthInformation obj)
    {
        throw new NotImplementedException();
    }
}