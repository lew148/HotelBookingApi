using HotelBookingApi.Models;

namespace HotelBookingApi.DTOs;

public class BookRoomRequest
{
    public int RoomId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int NumberOfGuests { get; set; }
    public PrimaryGuestInfo PrimaryGuestInfo { get; set; }
}

public class PrimaryGuestInfo
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ContactNumber { get; set; }
    public string? AddressLine1 { get; set; }
    public string? Town { get; set; }
    public string? PostCode { get; set; }
}