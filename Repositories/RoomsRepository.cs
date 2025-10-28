using HotelBookingApi.Common;
using HotelBookingApi.Models;

namespace HotelBookingApi.Repositories;

public interface IRoomsRepository
{
    List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate, RoomType roomType);
}

public class RoomsRepository : Repository, IRoomsRepository
{
    public RoomsRepository(DatabaseContext context) : base(context) { }


    public List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate, RoomType roomType) => Context.Rooms
        .Where(r => r.Type == roomType &&
                    !Context.Bookings.Any(b =>
                        b.RoomId == r.Id
                        && !(endDate <= b.CheckIn || startDate >= b.CheckOut))) // is overlapping
        .ToList();
}