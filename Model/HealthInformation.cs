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
    public List<string> Medicine_List { get; set; }

}