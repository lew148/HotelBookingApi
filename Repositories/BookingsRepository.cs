using HotelBookingApi.Common;
using HotelBookingApi.Models;

namespace HotelBookingApi.Repositories;

public interface IBookingsRepository
{
    Booking? AddBooking(string bookingReference, int roomId, int guestInfoId, DateTime checkIn, DateTime checkOut, int numberOfGuests);
}

public class BookingsRepository : Repository, IBookingsRepository
{
    public BookingsRepository(DatabaseContext context) : base(context) { }

    public Booking? AddBooking(string bookingReference,
        int roomId,
        int guestInfoId,
        DateTime checkIn,
        DateTime checkOut,
        int numberOfGuests)
    {
        try
        {
            var newBooking = new Booking
            {
                BookingReference = bookingReference,
                RoomId = roomId,
                PrimaryGuestId = guestInfoId,
                CheckIn = checkIn,
                CheckOut = checkOut,
                GuestCount = numberOfGuests,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            
            Context.Bookings.Add(newBooking);
            Context.SaveChanges();
            return newBooking;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}