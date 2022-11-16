namespace BlodBanken_Fabian_Henrik_Petrus;

internal class HealthInfoManager
{
    private HealthInformationDB _healthInfoDb = new();


    public bool VerifyHeight(string height)
    {
        if (Int32.TryParse(height, out int result)) return true;

        return false;
    }

    public bool VerifyWeight(string weight)
    {
        if (Int32.TryParse(weight, out int result)) return true;

        return false;
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

    public int SaveHealthInformationToDB(HealthInformation newHealthInformation)
    {
        int healthInformationId;
        healthInformationId = _healthInfoDb.Create(newHealthInformation);
        return healthInformationId;
    }
}