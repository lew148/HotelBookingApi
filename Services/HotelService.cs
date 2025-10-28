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
    
    public List<Hotel> GetHotels() => _repo.GetAll();
}