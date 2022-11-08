namespace BlodBanken_Fabian_Henrik_Petrus;

public class DataManager
{
    public void RegisterDonor(string values)
    {
        SQLWriter.sp_InsertInto("table", "columns", values);
    }
}