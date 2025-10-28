using HotelBookingApi.Models;
using HotelBookingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HotelController : ControllerBase
{
    private readonly IHotelService _hotelService;
    
    public HotelController(ILogger<HotelController> logger, IHotelService hotelService)
    {
        _hotelService = hotelService;
    }
    
    [HttpGet(Name = "GetHotels")]
    public List<Hotel> GetHotels()
    {
        return _hotelService.GetHotels();
    }
}