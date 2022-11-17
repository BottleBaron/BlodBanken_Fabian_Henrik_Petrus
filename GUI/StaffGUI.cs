using System.Reflection.Metadata.Ecma335;

namespace BlodBanken_Fabian_Henrik_Petrus;

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
        if (currentStock == null)
        {
            Console.WriteLine("Stock is empty");
            Console.ReadKey();
            return;
        }

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
        DonorManager donorMgr = new();

        List<Booking> bookingsToCheck = bookingMgr.GetPastBookingsByStaff(loggedInStaffMember);
        //TODO Du kan välja vilken bokning som helst. 
        Booking selectedBooking = new();
        while (true)
        {
            Console.Clear();
            if (bookingsToCheck.Count < 1)
            {
                Console.WriteLine("You currently have no bookings to check.");
                Console.ReadKey();
                return;
            }

            foreach (var booking in bookingsToCheck)
            {
                booking.GetNameValues();
                Console.WriteLine(booking.ToString());
            }

            Console.Write("Please enter an id:");
            string? stringSelection = Console.ReadLine();

            if (Int32.TryParse(stringSelection, out int result))
            {
                foreach (var booking in bookingsToCheck)
                {
                    if (result == booking.id)
                    {
                        selectedBooking = booking;
                        goto anchor;
                    }
                }
            }
            Console.WriteLine("Error: Entry was not valid or did not match a booking");
            Console.ReadKey();
        }

        anchor:

        bookingMgr.CheckBooking(selectedBooking);

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
        }

        Donor bloodTypeGetter = donorMgr.SelectDonor(selectedBooking.donor_id);
        bloodUnitMgr.EnterNewBloodUnits(unitsDonated, selectedBooking, bloodTypeGetter.blood_type);
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
            Console.WriteLine(
                $"A letter have been sent out to all donors with chosen bloodtype {bloodTypeKey.BloodType[result]}.");
            Console.ReadKey();
        }
    }
}