namespace BlodBanken_Fabian_Henrik_Petrus;

using System.Collections.Generic;
using Dapper;
using MySqlConnector;

internal class MedicinDB : DBConnection, ICrud<Medicin>
{
    public int Create(Medicin obj)
    {
       return 3; 
    }

    public void Delete(Medicin obj)
    {
        throw new NotImplementedException();
    }

    public List<Medicin> Read()
    {
        throw new NotImplementedException();
    }

    public void Update(Medicin obj)
    {
        throw new NotImplementedException();
    }

  
}