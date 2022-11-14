namespace BlodBanken_Fabian_Henrik_Petrus;

public class Donor
{
    // DataBase Properties
    public int id { get; }
    public string name { get; set; }
    public string phone_number { get; set; }
    public int blood_type { get; set; }
    public string address { get; set; }
    public DateTime date_of_birth { get; set; }

    // Runtime properties
    public BloodTypeKey key = new();  
}