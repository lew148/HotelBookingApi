using HotelBookingApi.Models;
using HotelBookingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HotelController(ILogger<HotelController> logger, IHotelService hotelService) : ControllerBase
{
    [HttpGet(Name = "GetHotels")]
    public List<Hotel> GetHotels()
    {
        return hotelService.GetHotels();
    }
}