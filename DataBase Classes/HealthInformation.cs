namespace BlodBanken_Fabian_Henrik_Petrus;

public class HealthInformation
{
    // DB Properties
    public int id { get; set; }
    public int donor_id { get; set; }
    public int donor_height { get; set; }
    public int donor_weight { get; set; }
    public bool is_drug_user { get; set; }
    public bool visited_high_risk_country { get; set; }
    
    // Runtime Properties
    public string DonorName { get; set; }
    public int BloodType { get; set; }
    public List<string> Medicine_List { get; set; }
    
    public HealthInformation()
    {
        List<Medicin> tempList = SQLWriter.sp_SelectTable<Medicin>("*", $"medicin WHERE id = {id}");
        foreach (var medicin in tempList)
        {
            Medicine_List.Add(medicin.medicine);
        }
    }
}