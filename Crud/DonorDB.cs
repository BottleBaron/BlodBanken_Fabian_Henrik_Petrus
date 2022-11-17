using System.Data;

namespace BlodBanken_Fabian_Henrik_Petrus;
using Dapper;
using MySqlConnector;

internal class DonorDB : DBConnection, ICrud<Donor>
{
    public List<Donor> Read()
    {
        string query = "SELECT * FROM donors";

        using (var connection = DBConnect())
        {
            try
            {
                var result = connection.Query<Donor>(query).ToList();
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

    public int Create(Donor obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "INSERT INTO donors (name, phone_number, blood_type, address, date_of_birth) " +
        "VALUES(@name, @phone_number, @blood_type, @address, @date_of_birth); SELECT MAX(id) FROM donors";

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

    public void Update(Donor obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "UPDATE donors " +
        "SET name = @name, phone_number = @phone_number, blood_type = @blood_type, address = @address, date_of_birth = @date_of_birth " +
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

    public void Delete(Donor obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "DELETE donors WHERE id = @id";

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

    public Donor SelectDonor(int id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@id", id);
        
        string query = "SELECT * FROM donors WHERE id = @id";
        
        using (var connection = DBConnect())
        {
            try
            {
                Donor donor = connection.QuerySingle<Donor>(query, parameters);
                return donor;
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