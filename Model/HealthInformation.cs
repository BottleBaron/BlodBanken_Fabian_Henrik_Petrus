namespace BlodBanken_Fabian_Henrik_Petrus;

public class HealthInformation
{
    // STRONG CONNECTION TO DONOR
    // DB Properties
    public int id { get; }
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

   public HealthInformation(int donorId, int donorHeight, int donorWeight, bool isDrugUser, bool haveVisitedHighRiskCountry)
    {
        donor_id = donorId;
        donor_height = donorHeight;
        donor_weight = donorWeight;
        is_drug_user = isDrugUser;
        visited_high_risk_country = haveVisitedHighRiskCountry;
    }
    
}