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
}