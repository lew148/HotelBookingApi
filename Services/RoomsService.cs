using HotelBookingApi.Common;
using HotelBookingApi.Models;
using HotelBookingApi.Repositories;

namespace HotelBookingApi.Services;

public interface IRoomsService
{
    List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate, int numberOfGuests);

    (bool, string?) BookRoom(int roomId, DateTime checkIn, DateTime checkOut, int numberOfGuests,
        PrimaryGuest primaryGuestInfo);
}

public class RoomsService : IRoomsService
{
    private readonly IRoomsRepository _repo;

    public RoomsService(IRoomsRepository repo) => _repo = repo;

    private List<RoomType> GetAvailableRoomTypesForNumberOfGuests(int numberOfGuests)
    {
        var roomTypes = new List<RoomType>();
        if (numberOfGuests <= 1) roomTypes.Add(RoomType.Single);
        if (numberOfGuests <= 2) roomTypes.Add(RoomType.Double);
        if (numberOfGuests <= 4) roomTypes.Add(RoomType.Deluxe);
        return roomTypes;
    }

    public List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate, int numberOfGuests)
    {
        var roomTypes = GetAvailableRoomTypesForNumberOfGuests(numberOfGuests);
        return roomTypes.Count == 0 ? [] : _repo.GetAvailableRooms(startDate, endDate, roomTypes);
    }

    public (bool, string?) BookRoom(int roomId,
        DateTime checkIn,
        DateTime checkOut,
        int numberOfGuests,
        PrimaryGuest primaryGuestInfo)
    {
        var room = _repo.GetRoomById(roomId, withBookings: true);
        if (room == null) return (false, "Room not found.");

        if (room.Bookings.All(b => checkOut <= b.CheckIn || checkIn >= b.CheckOut))
        {
            return (false, "This room is not available for the selected dates.");
        }

        var roomTypes = GetAvailableRoomTypesForNumberOfGuests(numberOfGuests);
        if (roomTypes.Count == 0 || !roomTypes.Contains(room.Type)) return (false, "There are too many guests for this room.");

        return (true, "");
    }
}