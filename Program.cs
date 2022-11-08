namespace BlodBanken_Fabian_Henrik_Petrus;

internal class Program
{
    private static void Main(string[] args)
    {
        // For testing
        DataManager dataManager = new();
        dataManager.CreateBooking("1, 1, false, NULL");
    }
}