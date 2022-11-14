namespace BlodBanken_Fabian_Henrik_Petrus;

public class Booking
{
    // DataBase Properties
    public int id { get; }
    public int donor_id { get; set; }
    public int staff_id { get; set; }
    public DateTime appointment_date { get; set; }
    public bool is_done { get; set; }

    // Runtime Properties
    public string DonorName { get; set; }
    public string StaffName { get; set; }
    public int BloodType { get; set; }

    public Booking()
    {
        //TODO: Get donorname, staffname & blood type
    }

    public override string ToString()
    {
        return $"{id} {donor_id}:{DonorName} {staff_id}:{StaffName} {appointment_date} {is_done}";
    }
}