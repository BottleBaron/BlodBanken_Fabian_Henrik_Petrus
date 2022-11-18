namespace BlodBanken_Fabian_Henrik_Petrus;

public class Donor
{
    // DataBase Properties
    public int Id { get; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public int BloodType { get; set; }
    public string Address { get; set; }
    public string DateOfBirth { get; set; }

    // Runtime properties
    public BloodTypeKey key = new();  
}