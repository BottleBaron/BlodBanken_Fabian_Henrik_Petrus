using System.Data;

namespace BlodBanken_Fabian_Henrik_Petrus;
using Dapper;
using MySqlConnector;

internal class DonorDB : DBConnection, ICrud<Donor>
{
    public List<Donor> Read()
    {
        string query = "SELECT id AS Id,name AS Name, phone_number AS PhoneNumber, blood_type AS BloodType, address AS Address, date_of_birth AS DateOfBirth FROM donors";

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
        "VALUES(@Name, @PhoneNumber, @BloodType, @address, @DateOfBirth); SELECT MAX(id) FROM donors";

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
        "SET name = @Name, phone_number = @PhoneNumber, blood_type = @BloodType, address = @Address, date_of_birth = @DateOfBirth " +
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

    public void Delete(Donor obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "DELETE FROM donors WHERE id = @Id";

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
    public void Delete(int id)
    {
        var parameters = new {Id = id};

        string query = "DELETE FROM donors WHERE id = @Id";

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
        parameters.Add("@Id", id);

        string query = "SELECT id AS Id, name AS Name, phone_number AS PhoneNumber, blood_type AS BloodType," +
        " address AS Address, date_of_birth AS DateOfBirth FROM donors WHERE id = @Id";

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


    public List<Donor> GetDonorByBloodType(int bloodType)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@BloodType", bloodType);

        string query = "SELECT id AS Id, name AS Name, phone_number AS PhoneNumber, blood_type AS BloodType, address AS Address," +
        " date_of_birth AS DateOfBirth FROM donors WHERE blood_type = @BloodType";

        using (var connection = DBConnect())
        {
            try
            {
                List<Donor> donorList = connection.Query<Donor>(query, parameters).ToList();
                return donorList;
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