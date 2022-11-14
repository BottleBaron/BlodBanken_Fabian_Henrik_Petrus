namespace BlodBanken_Fabian_Henrik_Petrus;

// Possibly better to move to GUI or Interface at a later stage to maintain good design principles
public class BloodTypeKey
{
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
}