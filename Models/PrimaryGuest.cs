namespace HotelBookingApi.Models;

public class PrimaryGuest : DatabaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ContactNumber { get; set; }
    public string AddressLine1 { get; set; }
    public string Town { get; set; }
    public string PostCode { get; set; }
}