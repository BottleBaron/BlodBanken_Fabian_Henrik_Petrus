namespace BlodBanken_Fabian_Henrik_Petrus;

internal class Program
{
    private static void Main(string[] args)
    {
        goto testing;

        DataManager myDatamanager = new();
        Donor newDonor = new();
        List<string> donorData = new();

        Console.WriteLine("name?");
        donorData.Add("'" + Console.ReadLine() + "'");

        Console.WriteLine("address?");
        donorData.Add("'" + Console.ReadLine() + "'");

        Console.WriteLine("phone number?");
        donorData.Add("'" + Console.ReadLine() + "'");

        Console.WriteLine("date of birth?");
        donorData.Add("'" + Console.ReadLine() + "'");

        Console.WriteLine("blood type?");
        string bloodType = Console.ReadLine();
        
        // for (int i = 0; i < newDonor.BloodType.Count; i++)
        // {
        //     if (bloodType == newDonor.BloodType[i])
        //     {
        //         donorData.Add("'" + i + "'");
        //     }
        //     else if (bloodType != newDonor.BloodType[i])
        //     {
        //     }
        // }

        string sqlString = SQLWriter.FormatIntoSqlString(donorData);
        myDatamanager.RegisterDonor(sqlString);
        
        testing:

        //For testing
        // DataManager dataManager = new();
        // dataManager.CreateBooking("1, 1, false, NULL");

        List<BloodUnit> listAllBloodUnits = new();

        foreach (var bloodUnit in listAllBloodUnits)
        {
            if(!bloodUnit.is_consumed) Console.WriteLine(bloodUnit.ToString());
        }
    }
}