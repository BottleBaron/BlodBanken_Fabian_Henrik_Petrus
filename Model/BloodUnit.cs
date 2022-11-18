namespace BlodBanken_Fabian_Henrik_Petrus;

public class BloodUnit
{
    //Database Properties
    public int Id { get; }
    public int DonorId { get; set; }
    public int BookingId { get; set; }
    public int BloodType { get; set; }
    public bool IsConsumed { get; set; }

    public BloodTypeKey key = new();

    public override string ToString()
    {
        return $"{Id} {DonorId} {BookingId} {key.BloodType[BloodType]}";
    }
}