namespace BlodBanken_Fabian_Henrik_Petrus;
using Dapper;
using MySqlConnector;

class DonorDB : ICrud<Donor>
{
    public MySqlConnection DBConnection()
    {
        var connection = new MySqlConnection("Server=localhost;Database=blodbank;Uid=root;");
        return connection;
    }

    public List<Donor> Read()
    {
        string query = "SELECT * FROM donors";

        using (var connection = DBConnection())
        {
            try
            {
                var result = connection.Query<Donor>(query).ToList();
                return result;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }

    public int Create(Donor donor)
    {
        var parameters = new DynamicParameters(donor);

        string query = "INSERT INTO donors (name, phone_number, blood_type, adress, date_of_birth) " +
        "OUTPUT INSERTED.id VALUES(@name, @phone_number, @blood_type, @adress, @date_of_birth)";

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

    public void Update(Donor donor)
    {
        var parameters = new DynamicParameters(donor);

        string query = "UPDATE donors " +
        "SET name = @name, phone_number = @phone_number, blood_type = @blood_type, adress = @adress, date_of_birth = @date_of_birth " +
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

    public void Delete(Donor donor)
    {
        var parameters = new DynamicParameters(donor);

        string query = "DELETE donors WHERE id = @id";

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
}