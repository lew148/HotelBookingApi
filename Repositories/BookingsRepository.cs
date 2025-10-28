using HotelBookingApi.Common;
using HotelBookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Repositories;

public interface IBookingsRepository
{
    Booking? AddBooking(string bookingReference, int roomId, int guestInfoId, DateTime checkIn, DateTime checkOut,
        int numberOfGuests);

    Booking? GetBookingByReference(string reference);
}

public class BookingsRepository : Repository, IBookingsRepository
{
    public BookingsRepository(DatabaseContext context) : base(context)
    {
    }

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

    public Booking? GetBookingByReference(string reference) => Context.Bookings
        .Include(b => b.PrimaryGuest)
        .Include(b => b.Room)
        .ThenInclude(r => r.Hotel)
        .FirstOrDefault(b => b.BookingReference == reference);
}