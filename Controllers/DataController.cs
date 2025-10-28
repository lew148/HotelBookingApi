using HotelBookingApi.DTOs;
using HotelBookingApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers;

[ApiController]
[Route("/api/data")]
public class DataController
{
    private readonly IDataRepository _dataRepository;

    public DataController(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }

    [HttpGet("SeedDatabase")]
    public ApiResponse SeedDatabase() =>
        _dataRepository.SeedDatabase()
            ? ApiResponse.Successful("Database successfully seeded")
            : ApiResponse.Failure("Failed to seed database");

    [HttpGet("ResetDatabase")]
    public ApiResponse ResetDatabase() =>
        _dataRepository.ResetDatabase()
            ? ApiResponse.Successful("Database successfully reset")
            : ApiResponse.Failure("Failed to reset database");
}