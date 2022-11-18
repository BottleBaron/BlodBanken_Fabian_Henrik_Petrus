using System.Reflection.Metadata.Ecma335;
using BlodBanken_Fabian_Henrik_Petrus;
using MySqlConnector;
using Dapper;

internal class HealthInformationDB : DBConnection, ICrud<HealthInformation>
{
    public List<HealthInformation> Read()
    {
        string query = "SELECT id AS Id, donor_id AS DonorId, donor_height AS DonorHeight, donor_weight AS DonorWeight,"+
         "is_drug_user AS IsDrugUser,visited_high_risk_country AS HasVisitedHighRiskCountry"+
         " FROM health_information";

        using (var connection = DBConnect())
        {
            try
            {
                var result = connection.Query<HealthInformation>(query).ToList();
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

    public int Create(HealthInformation obj)
    {
        var parameters = new DynamicParameters(obj);

        string query =
            $"INSERT INTO health_information (donor_id, donor_height, donor_weight, is_drug_user, visited_high_risk_country) " +
            "VALUES(@DonorId, @DonorHeight, @DonorWeight, @IsDrugUser, @HasVisitedHighRiskCountry); SELECT MAX(id) FROM health_information;";

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

    public void Update(HealthInformation obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "UPDATE health_information " +
                       "SET donor_id = @DonorId, donor_height = @DonorHeight, donor_weight = @DonorWeight, " +
                       "is_drug_user = @IsDrugUser, visited_high_risk_country = @HasVisitedHighRiskCountry" +
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

    public void Delete(HealthInformation obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "DELETE health_information where id = @Id";

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