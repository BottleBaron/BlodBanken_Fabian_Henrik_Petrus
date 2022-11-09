﻿namespace BlodBanken_Fabian_Henrik_Petrus;

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
        DataManager dataManager = new();
        // dataManager.CreateBooking("1, 1, false, NULL");

        // Works
        // List<BloodUnit> listAllBloodUnits = dataManager.GetAllBloodUnits();

        // foreach (var bloodUnit in listAllBloodUnits)
        // {
        //     if(!bloodUnit.is_consumed) Console.WriteLine(bloodUnit.ToString());
        // }

        // Works
        // Staff activeStaffMember = dataManager.TryLogin("3rnie", "stinky123");
        // Console.WriteLine(activeStaffMember.id + activeStaffMember.name);

        // Works
        //dataManager.SaveBloodUnits(2, 1);

        //Works
        List<Donor> AB = dataManager.GetDonors(5);
        foreach (var item in AB)
        {
            Console.WriteLine(item);
        }



        int donorHeight,donorWeight;
        bool isDrugUser,visitedHighRiskCountry;

        Console.WriteLine("What is your height in centimeters");
        donorHeight = ForceInt(Console.ReadLine());

        Console.WriteLine("What is your weight in kilograms");
        donorWeight = ForceInt(Console.ReadLine());

        Console.WriteLine("Have you been using drugs\n[Y]\n[N]");
       isDrugUser = ReturnBool();
        Console.WriteLine("Have you been abroad in a high risk country\n[Y]\n[N]");
        visitedHighRiskCountry = ReturnBool();

        HealthInformation myHealthinformation = new();
        //Spara till 
        List<Medicin> myMedicineList = new List<Medicin>();




    }

      public static int ForceInt(string inputString)
    {

        int result;
        if (int.TryParse(inputString, out result))
        {
            return result;
        }

        else
        {
            while (true)
            {
                Console.WriteLine("You have not entered a valid number, please try again");
                inputString = Console.ReadLine();
                if (int.TryParse(inputString, out result))
                {
                    return result;
                }
            }
        }
    }

    public static bool ReturnBool()
    {
        while (true)
        {
            char inputKey = Console.ReadKey(true).KeyChar;

            if (inputKey == 'Y' || inputKey == 'y')
            {
                return true;
            }
            else if (inputKey == 'N' || inputKey == 'n')
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }





}