using HotelBookingApi.Common;
using HotelBookingApi.Models;
using HotelBookingApi.Repositories;

namespace HotelBookingApi.Services;

public interface IRoomsService
{
    List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate, int numberOfGuests);
}

public class RoomsService : IRoomsService
{
    private readonly IRoomsRepository _repo;

    public RoomsService(IRoomsRepository repo) => _repo = repo;

    public List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate, int numberOfGuests)
    {
        RoomType? roomType = numberOfGuests switch
        {
            (<= 1) => RoomType.Single,
            (<= 2) => RoomType.Double,
            (<= 4) => RoomType.Deluxe,
            _ => null
        };

        return roomType == null ? [] : _repo.GetAvailableRooms(startDate, endDate, (RoomType)roomType);
    }
}