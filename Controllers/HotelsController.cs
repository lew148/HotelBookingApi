using HotelBookingApi.DTOs;
using HotelBookingApi.Models;
using HotelBookingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HotelsController : ControllerBase
{
    private readonly IHotelsService _hotelsService;

    public HotelsController(IHotelsService hotelsService)
    {
        _hotelsService = hotelsService;
    }

    [HttpGet("GetAllHotels")]
    public ApiResponse GetAllHotels() => ApiResponse<List<Hotel>>.Successful(_hotelsService.GetAllHotels());

    [HttpGet("GetHotel/{name}")]
    public ApiResponse GetHotel(string name)
    {
        var hotel = _hotelsService.GetHotelByName(name);
        return hotel is null
            ? ApiResponse.Failure("Hotel not found")
            : ApiResponse<Hotel>.Successful(hotel);
    }
}