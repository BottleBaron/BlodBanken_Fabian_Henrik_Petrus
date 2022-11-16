namespace BlodBanken_Fabian_Henrik_Petrus;


// Main menu
// 1. Visa
// 2. Välj -> 
//                                Event handler
//        UI                UI         v     Mngr          Crud
// 3. Skapa Profil -> ProfilSkaparMeny -> Validator -> Create Donor
// Välj Namn:
// Adress:
// etc.

class StaffGUI
{
    Staff loggedInStaffMember = new();

    public void MainMenu(Staff staffMember)
    {
        loggedInStaffMember = staffMember;

        while (true)
        {
            Console.Clear();
            string[] menuString = new string[]
            {
            "-- STAFF MENU--",
            "1.) Check Blood Stock",
            "2.) Confirm a Donation",
            "3.) Send Requests To Donors"
            };
            foreach (var line in menuString)
            {
                Console.WriteLine(line);
            }
            var key = Console.ReadKey();
            Console.Clear();

            if (key.Key == ConsoleKey.D1) CheckBloodStockMenu();
            else if (key.Key == ConsoleKey.D2) DonationConfirmMenu();
            else if (key.Key == ConsoleKey.D3) SendRequestMenu();
            else continue;
        }
    }

    private void CheckBloodStockMenu()
    {
        BloodUnitManager bloodUnitManager = new();
        Dictionary<string, int> currentStock = bloodUnitManager.GetBloodUnitsAmount();

        Console.WriteLine("-- CURRENT STOCK --");
        foreach (var keyValuePair in currentStock)
        {
            Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value} units");
        }
        Console.ReadKey();
    }

    private void DonationConfirmMenu()
    {
        BookingManager bookingMgr = new();
        BloodUnitManager bloodUnitMgr = new();

        List<Booking> bookingsToCheck = bookingMgr.GetPastBookingsByStaff(loggedInStaffMember);

        Booking selectedBooking = new();
        while (true)
        {
            Console.Clear();
            foreach (var booking in bookingsToCheck)
            {
                Console.WriteLine(booking.ToString());
            }
            Console.Write("Please enter an id:");
            string? stringSelection = Console.ReadLine();

            // Validate 
            if (Int32.TryParse(stringSelection, out int result))
            {
                foreach (var booking in bookingsToCheck)
                {
                    if (result == booking.id) selectedBooking = booking;
                    break;
                }
                break;
            }
            else
            {
                Console.WriteLine("Error: Entry was not valid or did not match a booking");
                Console.ReadKey();
                return;
            }
        }

        int unitsDonated;
        while (true)
        {
            Console.Clear();
            Console.Write("Booking Selected. Please enter the number of units donated: ");
            string? stringUnits = Console.ReadLine();

            if (Int32.TryParse(stringUnits, out int result)) 
            {
                unitsDonated = result;
                break;
            }
            else continue;
        }

        bookingMgr.CheckBooking(selectedBooking);
        bloodUnitMgr.EnterNewBloodUnits(unitsDonated, selectedBooking);
    }

    private void SendRequestMenu()
    {
        BloodTypeKey bloodTypeKey = new();

        Console.WriteLine("Select a bloodtype by entering a digit to request donations from registrered donors: \n");

        for (int i = 1; i < bloodTypeKey.BloodType.Count; i++)
        {
            Console.WriteLine($"{i}, {bloodTypeKey.BloodType[i]}");
        }

        Console.Write("\nYour choice: ");

        string? selectedBloodType = Console.ReadLine();
        if (Int32.TryParse(selectedBloodType, out int result))
        {
            Console.WriteLine($"A letter have been sent out to all donors with chosen bloodtype {bloodTypeKey.BloodType[result]}.");
            Console.ReadKey();
        }
    }
}


