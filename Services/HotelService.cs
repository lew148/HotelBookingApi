using HotelBookingApi.Models;
using HotelBookingApi.Repositories;

namespace HotelBookingApi.Services;

public interface IHotelService
{
    public List<Hotel> GetHotels();
}

public class HotelService : IHotelService
{
    private readonly IHotelsRepository _repo;

    public HotelService(IHotelsRepository repo) => _repo = repo;

    private static readonly string[] Names =
    [
        "Grandview Hotel",
        "Blue Ridge Hotel",
        "Skyline Inn",
        "Seabreeze Haven",
        "Golden Sands Retreat"
    ];

    public List<Hotel> GetHotels() => _repo.GetAll();
}