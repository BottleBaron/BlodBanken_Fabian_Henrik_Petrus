namespace BlodBanken_Fabian_Henrik_Petrus;

public class DataManager
{
    public void CreateBooking(string values)
    {
        string appointMentDate = DateTime.Now.AddDays(7).ToString("yy-MM-dd HH:mm:ss");
        SQLWriter.sp_InsertInto("bookings", "donor_id, staff_id, is_done, donated_amount, appointment_date", $"{values}, '{appointMentDate}'");
    }


    public void RegisterDonor(string values)
    {
        SQLWriter.sp_InsertInto("table", "columns", values);
    }
}