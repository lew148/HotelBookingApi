using HotelBookingApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController
{
    private readonly IDataRepository _dataRepository;

    public DataController(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }

    [HttpGet("SeedDatabase")]
    public bool SeedDatabase() => _dataRepository.SeedDatabase();

    [HttpGet("ResetDatabase")]
    public bool ResetDatabase() => _dataRepository.ResetDatabase();
}