namespace BlodBanken_Fabian_Henrik_Petrus;

public class Bookings
{
    // DataBase Properties
    public int id { get; set; }
    public int donor_id { get; set; }
    public int staff_id { get; set; }
    public DateTime appointment_date { get; set; }
    public bool is_done { get; set; }
    public int? donated_amount { get; set; }
    
    // Runtime Properties
    public string DonorName { get; set; }
    public string StaffName { get; set; }
}