namespace HotelBookingApi.DTOs;

public class GetAvailableRoomsRequest
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int NumberOfGuests { get; set; }
}