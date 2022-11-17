namespace BlodBanken_Fabian_Henrik_Petrus;

using System.Collections.Generic;
using Dapper;
using MySqlConnector;

internal class MedicinDB : DBConnection, ICrud<Medicin>
{
    public int Create(Medicin myMedicine)
    {
         var parameters = new DynamicParameters(myMedicine);
        
        string query = $"INSERT INTO medicin (health_info_id,medicine) " +
        "VALUES(@health_info_id, @medicine); SELECT LAST_INSERT_ID();";

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

    public void Delete(Medicin myMedicine)
    {
         var parameters = new DynamicParameters(myMedicine);

        string query = "DELETE blood_units WHERE id = @id";

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

    public List<Medicin> Read()
    {   
        string query = "SELECT * FROM medicin";
          using (var connection = DBConnect())
        {
            try
            {
                var medicine = connection.Query<Medicin>(query).ToList();

                return medicine;
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

    public void Update(Medicin myMedicine)
    {
         var parameters = new DynamicParameters(myMedicine);

        string query = $"UPDATE medicine " +
        "SET health_info_id = @health_info_id, medicine = @medicine " +
        "WHERE id = @id";

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

  
}