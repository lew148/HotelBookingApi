namespace HotelBookingApi.Models;

public class Room : DatabaseModel
{
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }
    
    public RoomType Type { get; set; }
}