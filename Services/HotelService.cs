using HotelBookingApi.Models;

namespace HotelBookingApi.Services;

public interface IHotelService
{
    public List<Hotel> GetHotels();
}

public class HotelService : IHotelService
{
    private static readonly string[] Names =
    [
        "Grandview Hotel",
        "Blue Ridge Hotel",
        "Skyline Inn",
        "Seabreeze Haven",
        "Golden Sands Retreat"
    ];

    public List<Hotel> GetHotels() => Names.Select(n => new Hotel { Name = n }).ToList();
}