namespace HotelBookingApi.Models;

public class Hotel : DatabaseModel
{
    public string Name { get; set; }
    
    public List<Room> Rooms { get; set; }
}