using HotelBookingApi.Common;
using HotelBookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Repositories;

public interface IRoomsRepository
{
    List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate, List<RoomType> roomTypes);
    Room? GetRoomById(int roomId, bool withBookings = false);
}

public class RoomsRepository : Repository, IRoomsRepository
{
    public RoomsRepository(DatabaseContext context) : base(context) { }


    public List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate, List<RoomType> roomTypes) => Context.Rooms
        .Where(r => roomTypes.Contains(r.Type) &&
                    !Context.Bookings.Any(b =>
                        b.RoomId == r.Id
                        && !(endDate <= b.CheckIn || startDate >= b.CheckOut))) // is overlapping
        .ToList();

    public Room? GetRoomById(int roomId, bool withBookings)
    {
        var query = Context.Rooms.AsQueryable();
        if (withBookings) query = query.Include(r => r.Bookings);
        return query.FirstOrDefault(r => r.Id == roomId);
    }
}