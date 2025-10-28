using HotelBookingApi.DTOs;
using HotelBookingApi.Models;
using HotelBookingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingsService _bookingsRepository;

    public BookingsController(IBookingsService bookingsRepository)
    {
        _bookingsRepository = bookingsRepository;
    }
    
    [HttpGet("GetBooking/{reference}")]
    public ApiResponse GetHotel(string reference)
    {
        var booking = _bookingsRepository.GetBookingByReference(reference);
        return booking is null
            ? ApiResponse.Failure("Booking not found")
            : ApiResponse<Booking>.Successful(booking);
    }
}