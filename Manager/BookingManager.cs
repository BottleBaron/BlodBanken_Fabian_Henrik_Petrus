namespace BlodBanken_Fabian_Henrik_Petrus;

internal class BookingManager
{
    private BookingDB _bookingDb = new();

    public List<Booking> GetBookingsByStaff(Staff staffMember)
    {
        List<Booking> relatedBookings = _bookingDb.SelectByStaffId(staffMember);
        return relatedBookings;
    }

    public List<Booking> GetPastBookingsByStaff(Staff staffMember)
    {
        List<Booking> relatedBookings = _bookingDb.SelectByStaffId(staffMember);

        relatedBookings.RemoveAll(booking => booking.AppointmentDate > DateTime.Now || booking.IsDone);

       return relatedBookings;
    }

    public void CheckBooking(Booking booking)
    {
        booking.IsDone = true;
        _bookingDb.Update(booking);
    }

    public Booking CreateSpaghettiBooking(int id)
    {
        var staffdb = new StaffDB();
        var random = new Random();
        
        List<Staff> listOfStaff = staffdb.Read();

        int rStaffId = random.Next(1, listOfStaff.Count);
        
        Booking newBooking = new Booking()
        {
            DonorId = id,
            StaffId = rStaffId,
            AppointmentDate = DateTime.Now.AddDays(7).AddMinutes(DateTime.Now.Minute % 15 == 0 ? 0 : 15 - DateTime.Now.Minute % 15).AddSeconds(DateTime.Now.Second % 60 == 0 ? 0 : 0 - DateTime.Now.Second % 60),
            IsDone = false
        };

        int newBookingId = _bookingDb.Create(newBooking);
        newBooking = _bookingDb.SelectByBookingId(newBookingId);

        return newBooking;
    }

    public void _DeleteBooking(Booking obj)
    {
        _bookingDb.DeleteBooking(obj);
    }
}