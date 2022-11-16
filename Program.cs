namespace BlodBanken_Fabian_Henrik_Petrus;

internal class Program
{
    private static void Main(string[] args)
    {
        DonorGUI donorGui = new();
        StaffGUI staffGui = new();
        StaffManager staffMngr = new();

        string[] coolLogo =  new string[]   
        {
         "           ██▓     ▒█████   ▒█████  ▓█████▄     ▄▄▄▄    ▄▄▄       ███▄    █  ██ ▄█▀ ",
         "  ▓█████▄ ▓██▒    ▒██▒  ██▒▒██▒  ██▒▒██▀ ██▌   ▓█████▄ ▒████▄     ██ ▀█   █  ██▄█▒  ",
         "  ▒██▒ ▄██▒██░    ▒██░  ██▒▒██░  ██▒░██   █▌   ▒██▒ ▄██▒██  ▀█▄  ▓██  ▀█ ██▒▓███▄░  ",
         "  ▒██░█▀  ▒██░    ▒██   ██░▒██   ██░░▓█▄   ▌   ▒██░█▀  ░██▄▄▄▄██ ▓██▒  ▐▌██▒▓██ █▄  ",
         "  ░▓█  ▀█▓░██████▒░ ████▓▒░░ ████▓▒░░▒████▓    ░▓█  ▀█▓ ▓█   ▓██▒▒██░   ▓██░▒██▒ █▄ ",
         "  ░▒▓███▀▒░ ▒░▓  ░░ ▒░▒░▒░ ░ ▒░▒░▒░  ▒▒▓  ▒    ░▒▓███▀▒ ▒▒   ▓▒█░░ ▒░   ▒ ▒ ▒ ▒▒ ▓▒ ",
         "  ▒░▒   ░ ░ ░ ▒  ░  ░ ▒ ▒░   ░ ▒ ▒░  ░ ▒  ▒    ▒░▒   ░   ▒   ▒▒ ░░ ░░   ░ ▒░░ ░▒ ▒░ ",
         "  ░    ░   ░ ░   ░ ░ ░ ▒  ░ ░ ░ ▒   ░ ░  ░     ░    ░   ░   ▒      ░   ░ ░ ░ ░░ ░   ",
         "  ░          ░  ░    ░ ░      ░ ░     ░        ░            ░  ░         ░ ░  ░     ",
         "       ░                            ░               ░                               ",
        };
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        foreach (var line in coolLogo)
        {
            Console.WriteLine(line);
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();

        while (true)
        {
            Console.Clear();

            string[] menu = new string[]
            {
                "-- BLOOD BANK --",
                "1). Become a donor",
                "2). Log in as a staff member",
                "3). Quit"
            };
            foreach (var line in menu)
            {
                Console.WriteLine(line);
            }
            var keyPress = Console.ReadKey(true);

            if (keyPress.Key == ConsoleKey.D1) donorGui.MainMenu();
            else if (keyPress.Key == ConsoleKey.D2) 
            {
                Console.Clear();

                Console.Write("Please enter your username:");
                string nameInput = Console.ReadLine();
                Console.Write("Please enter your password:");
                string passInput = Console.ReadLine();

                Staff staffMember = staffMngr.TryLogin(nameInput, passInput);

                if(staffMember != null) staffGui.MainMenu(staffMember);
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.ReadKey();
                    continue;
                }
            }
            else if (keyPress.Key == ConsoleKey.D3) Environment.Exit(0);
            else continue;
        }
    }
}