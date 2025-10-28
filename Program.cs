using HotelBookingApi.Common;
using HotelBookingApi.Repositories;
using HotelBookingApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IHotelsService, HotelsService>();
builder.Services.AddScoped<IRoomsService, RoomsService>();

builder.Services.AddScoped<IHotelsRepository, HotelsRepository>();
builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.AddScoped<IRoomsRepository, RoomsRepository>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandler>();
app.MapControllers();
app.Run();