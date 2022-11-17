namespace BlodBanken_Fabian_Henrik_Petrus;

internal class BookingManager
{
    private BookingDB _bookingDb = new();

    public List<Booking> GetPastBookingsByStaff(Staff staffMember)
    {
        List<Booking> relatedBookings = _bookingDb.SelectByStaffId(staffMember);

        relatedBookings.RemoveAll(booking => booking.appointment_date > DateTime.Now || booking.is_done);

       return relatedBookings;
    }

    public void CheckBooking(Booking booking)
    {
        booking.is_done = true;
        _bookingDb.Update(booking);
    }

    //TODO: [BIG ASSIGNMENT] Add selectable scheduling 
    public void CreateSpaghettiBooking(int id)
    {
        var staffdb = new StaffDB();
        Random random = new Random();
        
        List<Staff> listOfStaff = staffdb.Read();
        int rStaffId = random.Next(1,listOfStaff.Count);
        
        Booking newBooking = new Booking()
        {
            donor_id = id,
            staff_id = rStaffId,
            appointment_date = DateTime.Now.AddDays(7).AddMinutes(DateTime.Now.Minute % 15 == 0 ? 0 : 15 - DateTime.Now.Minute % 15),
            is_done = false
        };

        _bookingDb.Create(newBooking);
    }
}