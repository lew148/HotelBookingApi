using HotelBookingApi.Common;
using HotelBookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Repositories;

public interface IHotelsRepository
{
    List<Hotel> GetAllHotels();

    Hotel? GetHotelByName(string name);
}

public class HotelsRepository : Repository, IHotelsRepository
{
    public HotelsRepository(DatabaseContext context) : base(context) { }

    public List<Hotel> GetAllHotels() => Context.Hotels.Include(h => h.Rooms).ToList();

    public Hotel? GetHotelByName(string name) => Context.Hotels
        .Include(h => h.Rooms)
        .FirstOrDefault(h => h.Name.ToLower() == name.ToLower());
}