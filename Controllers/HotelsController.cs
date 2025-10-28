using HotelBookingApi.DTOs;
using HotelBookingApi.Models;
using HotelBookingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HotelsController : ControllerBase
{
    private readonly IHotelService _hotelService;

    public HotelsController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    [HttpGet("GetAllHotels")]
    public ApiResponse<List<Hotel>> GetAllHotels() => ApiResponse<List<Hotel>>.Successful(_hotelService.GetAllHotels());

    [HttpGet("GetHotel/{name}")]
    public ApiResponse GetHotel(string name)
    {
        var hotel = _hotelService.GetHotelByName(name);
        return hotel is null
            ? ApiResponse.Failure("Hotel not found")
            : ApiResponse<Hotel>.Successful(hotel);
    }
}