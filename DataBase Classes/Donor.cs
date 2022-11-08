namespace BlodBanken_Fabian_Henrik_Petrus;

public class Donor
{
    // DataBase Properties
    public int id { get; set; }
    public string name { get; set; }
    public string phone_number { get; set; }
    public int blood_type { get; set; }
    public string address { get; set; }
    public DateOnly date_of_birth { get; set; }

    DataManager myDataManager = new();
    
    // Runtime Properties
    public Dictionary<int, string> BloodType = new()
    {
        {0, "Unassigned"}, 
        {1, "A+"}, 
        {2, "A-"}, 
        {3, "B+"},
        {4, "B-"},
        {5, "AB+"},
        {6, "AB-"},
        {7, "O+"},
        {8, "O-"}
    };

    public Donor()
    {
        
    }
    
}