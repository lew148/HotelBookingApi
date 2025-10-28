using HotelBookingApi.Models;

namespace HotelBookingApi.DTOs;

public class BookRoomRequest
{
    public int RoomId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int NumberOfGuests { get; set; }
    public PrimaryGuest PrimaryGuestInfo { get; set; }
}