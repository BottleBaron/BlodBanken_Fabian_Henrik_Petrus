namespace BlodBanken_Fabian_Henrik_Petrus;

internal class HealthInfoManager
{
    private HealthInformationDB _healthInfoDb = new();


public bool VerifyHeight(string height)
{
    try
    {
        int donorHeight = Convert.ToInt32(height);

        return true;
    }
    catch (System.Exception)
    {
        
        
        return false;
    }
}

public bool VerifyWeight(string weight)
{
    try
    {
        int donorWeight = Convert.ToInt32(weight);
        
        return true;
    }
    catch (System.Exception)
    {
        
        
        return false;
    }
}

public bool? VerifyYesOrNo(ConsoleKey selector)
{
    if (selector == ConsoleKey.Y)
    {
        return true;
    }
    else if (selector == ConsoleKey.N)
    {
        return false;
    }

    else
    {
        return null;
    }
}



public int SaveHealthInformationToDB (HealthInformation newHealthInformation)
{
    int healthInformationId;
    healthInformationId = _healthInfoDb.Create(newHealthInformation);
    return healthInformationId;
}




}