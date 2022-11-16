namespace BlodBanken_Fabian_Henrik_Petrus;

class DonorGUI
{

    public void MainMenu()
    {
        BloodTypeKey bloodType = new();
        DonorManager donorManager = new();

        Console.WriteLine("Välkommen till Blodbanken. \n[1]\n\n");
        ConsoleKey selector = Console.ReadKey(true).Key;
        if (selector == ConsoleKey.D1 || selector == ConsoleKey.NumPad1)
        {
          int donorId =  RegisterDonor();
          Console.WriteLine(donorId);
          FillInHealthSurvey(donorId);
        }







    }

    private void FillInHealthSurvey(int donorId)
    
    { 
        HealthInfoManager healthInfoManager = new HealthInfoManager();
        HealthInformation newHealthInformation = new();
        bool isUsingMedicine; 
        
        newHealthInformation.donor_id = donorId;
        List <string> medicineList = new List<string>();
        
        //Height input
        while (true)
        {
        Console.WriteLine("What is your height in centimenters");
       string donorHeightStr = Console.ReadLine();

        if (healthInfoManager.VerifyHeight(donorHeightStr)== true)
        {   newHealthInformation.donor_height = Convert.ToInt32(donorHeightStr);
            break;
        }

        else Console.WriteLine("Incorrect value");   
        }

        //Weight input
        while (true)
        {
        Console.WriteLine("What is your weight in kilograms?");
        string donorWeightStr = Console.ReadLine();
         
         if (healthInfoManager.VerifyWeight(donorWeightStr)== true)
        {   newHealthInformation.donor_weight = Convert.ToInt32(donorWeightStr);
            break; 
        }

        else Console.WriteLine("Incorrect value");     
        
        }

        //Is druguser
        while (true)
        {        
        Console.WriteLine("Have you been using drugs\n[Y]\n[N]");
        ConsoleKey selector = Console.ReadKey(true).Key;
        
        if (healthInfoManager.VerifyYesOrNo(selector) != null)
        {
            newHealthInformation.is_drug_user = (bool)healthInfoManager.VerifyYesOrNo(selector);
            break;
        } 

        else Console.WriteLine("Incorrect value");
             
        }

         while (true)
        {        
        Console.WriteLine("Have you recently been in a high risk country?\n[Y]\n[N]");
        ConsoleKey selector = Console.ReadKey(true).Key;
        
        if (healthInfoManager.VerifyYesOrNo(selector) != null)
        {
            newHealthInformation.visited_high_risk_country = (bool)healthInfoManager.VerifyYesOrNo(selector);
            break;
        } 

        else Console.WriteLine("Incorrect value");  

        }

        while (true)
        {
            Console.WriteLine("Are you on any medications?\n[Y]\n[N]");
            ConsoleKey selector = Console.ReadKey(true).Key;

            if (healthInfoManager.VerifyYesOrNo(selector) != null)
            {
                isUsingMedicine = (bool)healthInfoManager.VerifyYesOrNo(selector);
                if (isUsingMedicine == true)
                {
                    medicineList = RegisterMedicines();
                    break;
                }
                else break;

            }
            else
            
                Console.WriteLine("Incorrect value");
            
        }

        //Save to DB
        int healthInformationId = healthInfoManager.SaveHealthInformationToDB(newHealthInformation);

        
        if (isUsingMedicine == true)
        {
            //Kalla på medicinemanager
        }
        

      
    }

 //   private List<string> RegisterMedicines()

    {   
        List<string> medicineList = new();
        MedicinManager medicinManager = new();
        string medicine;
        while (true)
        {
            
        
        Console.WriteLine("Please enter your medicine (one at the time)");
        medicine = Console.ReadLine();
        if (medicinManager.VerifyMedicine(medicine)== true)
        {
            medicineList.Add(medicine);
            Console.WriteLine(medicine + "added. Press [Y] to add another medicine or any other key to stop ");
            ConsoleKey selector = Console.ReadKey(true).Key;
            if (selector != ConsoleKey.Y)
            {
                break;
            }
        }
        }   
        return medicineList;
    }

    private int RegisterDonor()
    {
        Donor newDonor = new();
        DonorManager donorManager = new();
           
    
        //Name
        while (true)
        {

            Console.WriteLine("Please enter your full name?");
            string name = Console.ReadLine();
            if (donorManager.ValidateName(name) == true)
            {
                newDonor.name =name;
                break;
            }
            else Console.WriteLine("Incorrect input");
                                    
        }
        //Address
        while (true)
        {

            string?[] address = new string[3];
            Console.WriteLine("Enter your street address");

            address[0] = Console.ReadLine();
            Console.WriteLine("Enter your zipcode");
            address[1] = Console.ReadLine();
            Console.WriteLine("Enter your city");
            address[2] = Console.ReadLine();

            if (donorManager.ValidateAddress(address) == true)
            {
                newDonor.address = (address[0]+", "+ address[1]+", "+ address[2]);
                break;
            }
            else Console.WriteLine("Incorrect input");  
            
        }

        //PhoneNumber
        while (true)
        {

            Console.WriteLine("Enter your phone number?");
            string phoneNumber = Console.ReadLine();
            if (donorManager.ValidatePhoneNumber(phoneNumber) == true)
            {   
                newDonor.phone_number = phoneNumber;
                break;
            }
            else Console.WriteLine("Incorrect input");  
          
            
        }

        //Date of Birth
        while (true)
        {

            Console.WriteLine("Enter your date of birth YYYYmmdd");
            string dateOfBirth = Console.ReadLine();

            if (donorManager.ValidateDateOfBirth(dateOfBirth) == true)
            {
                newDonor.date_of_birth = dateOfBirth;
            break;
            }
            else Console.WriteLine("Incorrect input"); 
                                        
        }

         while (true)
    {   //Prints the different bloodgroups in the dictionary starting from 1. 
        for (int i = 1; i < newDonor.key.BloodType.Count; i++)
        {   
            var kvp = newDonor.key.BloodType.ElementAt(i);
            int itemKey = kvp.Key;
            string itemValue = kvp.Value;
            Console.WriteLine($"[{kvp.Key}] {kvp.Value}");
        }

        char keyPress = Console.ReadKey(true).KeyChar; 
        //Validates that the keypress represents a bloodgroup. 
        if (donorManager.ValidateBloodGroup(keyPress) == true)
        {
            //Sets the property and exits the for loop. 
            newDonor.blood_type = Convert.ToInt32(keyPress.ToString());
            break;
        }
        else Console.WriteLine("Wrong input");
    }


        //Save the donorobject to the DB
        int savedDonorId =  donorManager.SaveDonorToDB(newDonor);
        return savedDonorId;
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


