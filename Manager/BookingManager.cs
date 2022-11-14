namespace BlodBanken_Fabian_Henrik_Petrus;

internal class BookingManager
{
    private BookingDB _bookingDb = new();

    public List<Booking> GetPastBookingsByStaff(Staff staffMember)
    {
        List<Booking> relatedBookings = _bookingDb.SelectWhere("id", staffMember.id);

        // Checks if appointment date has passed
        foreach (var booking in relatedBookings)
        {
            if (booking.appointment_date > DateTime.Now || booking.is_done) relatedBookings.Remove(booking);
        }

        return relatedBookings;
    }

    public void CheckBooking(Booking booking)
    {
        booking.is_done = true;
        _bookingDb.Update(booking);
    }
}