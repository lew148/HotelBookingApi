namespace HotelBookingApi.Models;

public class Booking : DatabaseModel
{
    public int RoomId { get; set; }
    public int PrimaryGuestId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public string BookingReference { get; set; }
    public int GuestCount { get; set; }
}