namespace BlodBanken_Fabian_Henrik_Petrus;

public class DataManager
{
    public void CreateBooking(string values)
    {
        DateTime appointMentDate = DateTime.Now.AddDays(7);
    
        SQLWriter.sp_InsertInto("bookings", "donor_id, staff_id, appointment_date, is_done, donated_amount", values + appointMentDate);
    }

    
    public void RegisterDonor(string values)
    {
        SQLWriter.sp_InsertInto("table", "columns", values);
    }
}