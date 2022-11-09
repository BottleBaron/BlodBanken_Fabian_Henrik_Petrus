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

    public int RegisterDonor(string values)
    {
        SQLWriter.sp_InsertInto("donors", "name, address, phone_number, date_of_birth, blood_type", values);
        int id = SQLWriter.SelectLastID("id", "donors");

        return id;
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

    // From Confirmed donation 
    public void SaveBloodUnits(int numberOfUnits, int bookingId)
    {
        // Maybe put bloodtype in booking?
        Booking thisBooking = SQLWriter.sp_SelectObject<Booking>("*", "bookings", $"id = {bookingId}");
        Donor thisDonor = SQLWriter.sp_SelectObject<Donor>("blood_type", "donors", $"id = {thisBooking.donor_id}");

        for (int i = 0; i < numberOfUnits; i++)
        {
            SQLWriter.sp_InsertInto("blood_units", "donor_id, booking_id, blood_type", $"{thisBooking.donor_id}, {bookingId}, {thisDonor.blood_type}");
        }

        SQLWriter.sp_UpdateTable("bookings", $"is_done = 1", $"id = {bookingId}");
        SQLWriter.sp_UpdateTable("bookings", $"donated_amount = {numberOfUnits}", $"id = {bookingId}");
    }

    public List<Donor> GetDonors(int bloodType)
    {
        List<Donor> foundDonors = SQLWriter.sp_SelectTable<Donor>("*", $"donors WHERE blood_type = {bloodType}");
        return foundDonors;
    }


      public void SaveHealthInformation(HealthInformation myHealthInformation)
    {
        SQLWriter.sp_InsertInto("health_information", "`donor_id`, `donor_height`, `donor_weight`, `is_drug_user`, `visited_high_risk_country`",$"{myHealthInformation.donor_id}, {myHealthInformation.donor_height}, {myHealthInformation.donor_weight},{myHealthInformation.is_drug_user},{myHealthInformation.visited_high_risk_country}");

    }


    public void SaveMedicinList(List<Medicin> myMedicineList)

    {   foreach (var m in myMedicineList)
    {
         SQLWriter.sp_InsertInto("`medicin`","`health_info_id`, `medicine`",$"{m.health_info_id},{m.medicine}");
    }
       
    }
}   
