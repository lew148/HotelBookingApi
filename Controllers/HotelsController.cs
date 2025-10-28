using HotelBookingApi.DTOs;
using HotelBookingApi.Models;
using HotelBookingApi.Repositories;
using HotelBookingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HotelsController : ControllerBase
{
    private readonly IHotelsRepository _hotelsRepository;

    public HotelsController(IHotelsRepository hotelsRepository)
    {
        _hotelsRepository = hotelsRepository;
    }

    [HttpGet("GetAllHotels")]
    public ApiResponse GetAllHotels() => ApiResponse<List<Hotel>>.Successful(_hotelsRepository.GetAllHotels());

    [HttpGet("GetHotel/{name}")]
    public ApiResponse GetHotel(string name)
    {
        var hotel = _hotelsRepository.GetHotelByName(name);
        return hotel is null
            ? ApiResponse.Failure("Hotel not found")
            : ApiResponse<Hotel>.Successful(hotel);
    }
}