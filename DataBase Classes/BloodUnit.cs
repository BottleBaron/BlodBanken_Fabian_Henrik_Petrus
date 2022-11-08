namespace BlodBanken_Fabian_Henrik_Petrus;

public class BloodUnit
{
    public int id { get; set; }
    public int donor_id { get; set; }
    public int blood_type { get; set; }
    public bool is_consumed { get; set; }

    public override string ToString()
    {
        return $"{id} {donor_id} {blood_type}";
    }
}