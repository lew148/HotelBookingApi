using HotelBookingApi.Models;

namespace HotelBookingApi.Repositories;

public interface IHotelsRepository
{
    List<Hotel> GetAll();
}

public class HotelsRepository : Repository, IHotelsRepository
{
    public HotelsRepository(DatabaseContext context) : base(context) { }
    
    public List<Hotel> GetAll() => Context.Hotels.ToList();
}