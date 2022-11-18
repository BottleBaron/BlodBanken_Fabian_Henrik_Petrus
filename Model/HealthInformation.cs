namespace BlodBanken_Fabian_Henrik_Petrus;

public class HealthInformation
{
    // STRONG CONNECTION TO DONOR
    // DB Properties
    public int Id { get; }
    public int DonorId { get; set; }
    public int DonorHeight { get; set; }
    public int DonorWeight { get; set; }
    public bool IsDrugUser { get; set; }
    public bool HasVisitedHighRiskCountry { get; set; }
    
    // Runtime Properties
    public string DonorName { get; set; }
    public int BloodType { get; set; }
    public List<string> Medicine_List { get; set; }
    
    public HealthInformation()
    {
    }

   public HealthInformation(int donorId, int donorHeight, int donorWeight, bool isDrugUser, bool haveVisitedHighRiskCountry)
    {
        DonorId = donorId;
        DonorHeight = donorHeight;
        DonorWeight = donorWeight;
        IsDrugUser = isDrugUser;
        HasVisitedHighRiskCountry = haveVisitedHighRiskCountry;
    }
    
}