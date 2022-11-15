namespace BlodBanken_Fabian_Henrik_Petrus;

class DonorGUI
{

    public void MainMenu()
    {
        BloodTypeKey bloodType = new();
        DonorManager donorManager = new();

        Console.WriteLine("Välkommen till Blodbanken. \n[1]");
        ConsoleKey selector = Console.ReadKey(true).Key;
        if (selector == ConsoleKey.D1 || selector == ConsoleKey.NumPad1)
        {
            RegisterDonor();
        }







    }

    private void FillInHealthSurvey()
    
    { 
        HealthInfoManager healthInfoManager = new HealthInfoManager();
        string donorHeightStr,donorWeightStr;
        int donorHeight, donorWeight;
        bool isDrugUser, visitedHighRiskCountry,isUsingMedicine;
        List <string> medicineList = new List<string>();
        
        while (true)
        {
            
        
        Console.WriteLine("Vad är din längd i centimeter");
        donorHeightStr = Console.ReadLine();
        if (healthInfoManager.VerifyHeight(donorHeightStr)== true)
        {   donorHeight = Convert.ToInt32(donorHeightStr);
            break;
        }

        else
        {
            Console.WriteLine("Felaktig inmatning");
            
        }
        }

        while (true)
        {
            
        
        Console.WriteLine("Vad är din vikt i kilogram?");
        donorWeightStr = Console.ReadLine();
         
         if (healthInfoManager.VerifyWeight(donorWeightStr)== true)
        {   donorWeight = Convert.ToInt32(donorWeightStr);
            break;
        }

        else
        {
            Console.WriteLine("Felaktig inmatning");
            
        }
        }
        while (true)
        {        
        Console.WriteLine("Have you been using drugs\n[Y]\n[N]");
        ConsoleKey selector = Console.ReadKey(true).Key;
        
        if (healthInfoManager.VerifyYesOrNo(selector) != null)
        {
            isDrugUser = (bool)healthInfoManager.VerifyYesOrNo(selector);
            break;
        } 

        else
        {
            Console.WriteLine("Felaktigt svar");
        }

        }
         while (true)
        {        
        Console.WriteLine("Har du nyligen varit utomlands i ett högriskland?\n[Y]\n[N]");
        ConsoleKey selector = Console.ReadKey(true).Key;
        
        if (healthInfoManager.VerifyYesOrNo(selector) != null)
        {
            visitedHighRiskCountry = (bool)healthInfoManager.VerifyYesOrNo(selector);
            break;
        } 

        else
        {
            Console.WriteLine("Felaktigt svar");
        }

        }



        while (true)
        {
            Console.WriteLine("Tar du några mediciner\n[Y]\n[N]");
            ConsoleKey selector = Console.ReadKey(true).Key;

            if (healthInfoManager.VerifyYesOrNo(selector) != null)
            {
                isUsingMedicine = (bool)healthInfoManager.VerifyYesOrNo(selector);
                if (isUsingMedicine == true)
                {
                    
                }

            }
            else
            {
                Console.WriteLine("Felaktig inmatning");
            }
        }
        HealthInformation myHealthinformation = new();
        //Spara till 
        List<Medicin> myMedicineList = new List<Medicin>();

      
    }

 //   private List<string> RegisterMedicines()

    // {   
    //     List<string> medicineList = new();
    //     MedicinManager medicinManager = new();
    //     string medicine;
    //     medicine = Console.ReadLine();
    //     if (medicinManager.VerifyMedicine(medicine)== true)
    //     {
    //         medicineList.Add(medicine);
    //     }
    // }

    private void RegisterDonor()
    {

        DonorManager donorManager = new();

        //Name
        while (true)
        {

            Console.WriteLine("Ange ditt fullständiga namn?");
            string name = Console.ReadLine();
            if (donorManager.ValidateName(name) == true)
            {
                break;
            }
            else
            {

               Console.WriteLine("Felaktig inmatning");
  
            }

           
        }
        //Address
        while (true)
        {

            string?[] address = new string[3];
            Console.WriteLine("Ange din gatuadress");

            address[0] = Console.ReadLine();
            Console.WriteLine("Ange ditt postnummer");
            address[1] = Console.ReadLine();
            Console.WriteLine("Ange din postort");
            address[2] = Console.ReadLine();

            if (donorManager.ValidateAddress(address) == true)
            {
                break;
            }
            else
            {
                Console.WriteLine("Felaktig inmatning");
            }
            
        }

        //PhoneNumber
        while (true)
        {

            Console.WriteLine("Vänligen ange ditt telefonnummer?");
            string phoneNumber = Console.ReadLine();
            if (donorManager.ValidatePhoneNumber(phoneNumber) == true)
            {
                break;
            }
            else
            {
              Console.WriteLine("Felaktig inmatning");  
            }
            
        }

        //Date of Birth
        while (true)
        {

            Console.WriteLine("Ange ditt födelsedatum YYYYmmdd");
            string dateOfBirth = Console.ReadLine();

            if (donorManager.ValidateDateOfBirth(dateOfBirth) == true)
            {
                break;
            }
            else
            {
               Console.WriteLine("Felaktig inmatning"); 
            }
           
        }

    }

}


// Main menu
// 1. Visa
// 2. Välj -> 
//                                Event handler
//        UI                UI         v     Mngr          Crud
// 3. Skapa Profil -> ProfilSkaparMeny -> Validator -> Create Donor
// Välj Namn:
// Adress:
// etc.


