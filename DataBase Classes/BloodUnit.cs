namespace BlodBanken_Fabian_Henrik_Petrus;

public class BloodUnit : IComparable
{
    public int id { get; set; }
    public int donor_id { get; set; }
    public int blood_type { get; set; }
    public bool is_consumed { get; set; }

    public int CompareTo(object x)
    {
        if(x == null) return 1;

        BloodUnit b = x as BloodUnit;

        if(b != null) return this.blood_type.CompareTo(b.blood_type);
        else throw new ArgumentException("Object is not a BloodUnit");
    }
}