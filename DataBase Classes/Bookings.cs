namespace BlodBanken_Fabian_Henrik_Petrus;

public class Bookings
{
    private int id { get; set; }
    private int donor_id { get; set; }
    private int staff_id { get; set; }
    private DateTime appointment_date { get; set; }
    private bool is_done { get; set; }
    private int donated_amount { get; set; }
    private string donor_name { get; set; }
    private string staff_name { get; set; }
}