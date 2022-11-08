namespace BlodBanken_Fabian_Henrik_Petrus;

internal class Program
{
    private static void Main(string[] args)
    {
        

        DataManager myDatamanager = new();
        List<string> donorData = new();

        Console.WriteLine("name?");
        donorData.Add(Console.ReadLine());

        Console.WriteLine("address?");
        donorData.Add(Console.ReadLine());

        Console.WriteLine("phone number?");
        donorData.Add("'" + Console.ReadLine() + "'");

        Console.WriteLine("date of birth?");
        donorData.Add("'" + Console.ReadLine() + "'");

        // Console.WriteLine("blood type?");
        // donorData.Add(Console.ReadLine());

        string sqlString = SQLWriter.FormatIntoSqlString(donorData);
        myDatamanager.RegisterDonor(sqlString);
        
        // For testing
        DataManager dataManager = new();
        dataManager.CreateBooking("1, 1, false, NULL");
    }
}