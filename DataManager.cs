namespace BlodBanken_Fabian_Henrik_Petrus;

public class DataManager
{
    // DONOR FUNCTIONALITY
    public int CreateBooking(string values)
    {
        string appointmentDate = DateTime.Now.AddDays(7).ToString("yy-MM-dd HH:mm:ss");
        SQLWriter.sp_InsertInto("bookings", "donor_id, staff_id, is_done, donated_amount, appointment_date", $"{values}, '{appointmentDate}'");

        Booking thisBooking = SQLWriter.sp_SelectObject<Booking>("id", "bookings", $"appointment_date = {appointmentDate}");
        return thisBooking.id;
    }

    public void RegisterDonor(string values)
    {
        SQLWriter.sp_InsertInto("donors", "name, address, phone_number, date_of_birth, blood_type", values);
    }

    // STAFF FUNTIONALITY

    public Staff TryLogin(string loginName, string passWord)
    {
        List<Staff> allStaffList = SQLWriter.sp_SelectTable<Staff>("*", "staff");

        foreach (var staff in allStaffList)
        {
            if(loginName == staff.login_name && passWord == staff.password) return staff;
        }

        return null;
    }

    public List<BloodUnit> GetAllBloodUnits()
    {
        List<BloodUnit> allbloodUnits = SQLWriter.sp_SelectTable<BloodUnit>("id, donor_id, booking_id, blood_type, is_consumed", "blood_units");

        allbloodUnits.Sort(new BloodUnitComparer());

        return allbloodUnits;
    }


}