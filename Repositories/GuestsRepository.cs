using HotelBookingApi.Common;
using HotelBookingApi.DTOs;
using HotelBookingApi.Models;

namespace HotelBookingApi.Repositories;

public interface IGuestsRepository
{
    PrimaryGuest? GetGuestByInfo(PrimaryGuestInfo info);
    PrimaryGuest? AddGuest(PrimaryGuestInfo info);
}

public class GuestsRepository : Repository, IGuestsRepository
{
    public GuestsRepository(DatabaseContext context) : base(context)
    {
    }

    public PrimaryGuest? GetGuestByInfo(PrimaryGuestInfo info) => Context.PrimaryGuests
        .FirstOrDefault(g => g.FirstName.ToLower() == info.FirstName.ToLower()
                             && g.LastName.ToLower() == info.LastName.ToLower()
                             && g.ContactNumber.ToLower() == info.ContactNumber.ToLower());

    public PrimaryGuest? AddGuest(PrimaryGuestInfo info)
    {
        try
        {
            var guest = new PrimaryGuest
            {
                FirstName = info.FirstName,
                LastName = info.LastName,
                ContactNumber = info.ContactNumber,
                AddressLine1 = info.AddressLine1,
                Town = info.Town,
                PostCode = info.PostCode,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            Context.PrimaryGuests.Add(guest);
            Context.SaveChanges();
            return guest;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}