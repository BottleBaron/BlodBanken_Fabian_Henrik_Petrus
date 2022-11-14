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

        }







    }

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


