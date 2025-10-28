using HotelBookingApi.DTOs;
using HotelBookingApi.Models;
using HotelBookingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers;

public class RoomsController : ControllerBase
{
    private readonly IRoomsService _roomService;

    public RoomsController(IRoomsService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet("AvailableRooms")]
    public ApiResponse<List<Room>> GetAvailableRooms([FromQuery] GetAvailableRooms request) =>
        ApiResponse<List<Room>>.Successful(_roomService.GetAvailableRooms(request.StartDate,
            request.EndDate,
            request.NumberOfGuests));
}