using HotelBookingApi.DTOs;
using HotelBookingApi.Models;
using HotelBookingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers;

[ApiController]
[Route("/api/rooms")]
public class RoomsController : ControllerBase
{
    private readonly IRoomsService _roomService;

    public RoomsController(IRoomsService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet("AvailableRooms")]
    public ApiResponse GetAvailableRooms([FromQuery] GetAvailableRoomsRequest request) =>
        ApiResponse<List<Room>>.Successful(_roomService.GetAvailableRooms(request.StartDate,
            request.EndDate,
            request.NumberOfGuests));

    [HttpPost("BookRoom")]
    public ApiResponse BookRoom([FromBody] BookRoomRequest? request)
    {
        if (request == null) return ApiResponse.Failure("Bad request.");
        
        var bookingResult =
            _roomService.BookRoom(request.RoomId,
                request.CheckIn,
                request.CheckOut,
                request.NumberOfGuests,
                request.PrimaryGuestInfo);

        return bookingResult.Item1 && !string.IsNullOrWhiteSpace(bookingResult.Item2)
            ? ApiResponse<string>.Successful(bookingResult.Item2)
            : ApiResponse.Failure(bookingResult.Item2 ?? "Booking failed. Please try again later.");
    }
}