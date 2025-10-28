using HotelBookingApi.Models;
using HotelBookingApi.Repositories;

namespace HotelBookingApi.Services;

public interface IHotelService
{
    public List<Hotel> GetAllHotels();
    
    Hotel? GetHotelByName(string name);
}

public class HotelService : IHotelService
{
    private readonly IHotelsRepository _repo;

    public HotelService(IHotelsRepository repo) => _repo = repo;
    
    public List<Hotel> GetAllHotels() => _repo.GetAllHotels();
    
    public Hotel? GetHotelByName(string name) => _repo.GetHotelByName(name);
}