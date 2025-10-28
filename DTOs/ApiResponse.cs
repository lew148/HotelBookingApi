namespace HotelBookingApi.DTOs;

public class ApiResponse
{
    public bool Success { get; init; }
    public string? Message { get; init; }

    public static ApiResponse Successful(string? message = null) => new() { Success = true, Message = message };

    public static ApiResponse Failure(string? message = null) => new() { Success = false, Message = message };
}

public class ApiResponse<T> : ApiResponse
{
    public T? Data { get; set; }

    public static ApiResponse<T> Successful(T data, string? message = null) =>
        new() { Success = true, Data = data, Message = message };
}