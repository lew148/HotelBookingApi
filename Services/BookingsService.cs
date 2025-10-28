using HotelBookingApi.DTOs;
using HotelBookingApi.Models;
using HotelBookingApi.Repositories;

namespace HotelBookingApi.Services;

public interface IBookingsService
{
    (bool, string?) CreateBooking(int roomId,
        DateTime checkIn,
        DateTime checkOut,
        int numberOfGuests,
        PrimaryGuestInfo primaryGuestInfo);

    Booking? GetBookingByReference(string reference);
}

public class BookingsService : IBookingsService
{
    private IBookingsRepository _bookingsRepo;
    private IGuestsRepository _guestsRepo;

    public BookingsService(IBookingsRepository bookingsRepo, IGuestsRepository guestsrepo)
    {
        _bookingsRepo = bookingsRepo;
        _guestsRepo = guestsrepo;
    }

    public (bool, string?) CreateBooking(int roomId,
        DateTime checkIn,
        DateTime checkOut,
        int numberOfGuests,
        PrimaryGuestInfo primaryGuestInfo)
    {
        var guestInfo = _guestsRepo.GetGuestByInfo(primaryGuestInfo);
        if (guestInfo == null)
        {
            var newGuest = _guestsRepo.AddGuest(primaryGuestInfo);
            if (newGuest == null) return (false, "Failed to add primary guest.");
            guestInfo = newGuest;
        }
        
        var bookingReference = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        var booking = _bookingsRepo.AddBooking(bookingReference, roomId, guestInfo.Id, checkIn, checkOut, numberOfGuests);
        return booking == null ? (false, "Failed to create booking.") : (true, booking.BookingReference);
    }

    public Booking? GetBookingByReference(string reference) => _bookingsRepo.GetBookingByReference(reference);
}