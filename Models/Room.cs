namespace HotelBookingApi.Models;

public class Room : DatabaseModel
{
    public int HotelId { get; set; }
    public RoomType Type { get; set; }
    public int Capacity { get; set; }
}