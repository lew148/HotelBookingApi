using HotelBookingApi.Models;
using HotelBookingApi.Repositories;

namespace HotelBookingApi.Services;

public interface IHotelsService
{
    public List<Hotel> GetAllHotels();
    Hotel? GetHotelByName(string name);
}

public class HotelsService : IHotelsService
{
    private readonly IHotelsRepository _repo;

    public HotelsService(IHotelsRepository repo) => _repo = repo;
    
    public List<Hotel> GetAllHotels() => _repo.GetAllHotels();
    
    public Hotel? GetHotelByName(string name) => _repo.GetHotelByName(name);
}