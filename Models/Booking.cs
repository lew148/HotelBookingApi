namespace HotelBookingApi.Models;

public class Booking : DatabaseModel
{
    public int RoomId { get; set; }
    public Room Room { get; set; }

    public int PrimaryGuestId { get; set; }
    public PrimaryGuest PrimaryGuest { get; set; }

    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public string BookingReference { get; set; }
    public int GuestCount { get; set; }
}