using HotelBookingApi.Common;
using HotelBookingApi.Models;

namespace HotelBookingApi.Repositories;

public interface IDataRepository
{
    public bool SeedDatabase();
    public bool ResetDatabase();
}

public class DataRepository : Repository, IDataRepository
{
    public DataRepository(DatabaseContext context) : base(context) { }

    public bool SeedDatabase()
    {
        if (Context.Hotels.Any()) return false;

        var now = DateTime.UtcNow;

        var hotels = new List<Hotel>
        {
            new Hotel { Name = "Grand Plaza", CreatedAt = now, UpdatedAt = now },
            new Hotel { Name = "Seaside Resort", CreatedAt = now, UpdatedAt = now },
            new Hotel { Name = "Elm Grove Inn", CreatedAt = now, UpdatedAt = now }
        };
        
        Context.Hotels.AddRange(hotels);
        Context.SaveChanges();

        var rooms = new List<Room>
        {
            new Room { HotelId = hotels[0].Id, Type = RoomType.Single, CreatedAt = now, UpdatedAt = now },
            new Room { HotelId = hotels[0].Id, Type = RoomType.Single, CreatedAt = now, UpdatedAt = now },
            new Room { HotelId = hotels[0].Id, Type = RoomType.Single, CreatedAt = now, UpdatedAt = now },
            new Room { HotelId = hotels[0].Id, Type = RoomType.Double, CreatedAt = now, UpdatedAt = now },
            new Room { HotelId = hotels[0].Id, Type = RoomType.Double, CreatedAt = now, UpdatedAt = now },
            new Room { HotelId = hotels[0].Id, Type = RoomType.Deluxe, CreatedAt = now, UpdatedAt = now },

            new Room { HotelId = hotels[1].Id, Type = RoomType.Single, CreatedAt = now, UpdatedAt = now },
            new Room { HotelId = hotels[1].Id, Type = RoomType.Single, CreatedAt = now, UpdatedAt = now },
            new Room { HotelId = hotels[1].Id, Type = RoomType.Deluxe, CreatedAt = now, UpdatedAt = now },
            new Room { HotelId = hotels[1].Id, Type = RoomType.Deluxe, CreatedAt = now, UpdatedAt = now },
            new Room { HotelId = hotels[1].Id, Type = RoomType.Deluxe, CreatedAt = now, UpdatedAt = now },
            new Room { HotelId = hotels[1].Id, Type = RoomType.Double, CreatedAt = now, UpdatedAt = now },

            new Room { HotelId = hotels[2].Id, Type = RoomType.Single, CreatedAt = now, UpdatedAt = now },
            new Room { HotelId = hotels[2].Id, Type = RoomType.Single, CreatedAt = now, UpdatedAt = now },
            new Room { HotelId = hotels[2].Id, Type = RoomType.Single, CreatedAt = now, UpdatedAt = now },
            new Room { HotelId = hotels[2].Id, Type = RoomType.Double, CreatedAt = now, UpdatedAt = now },
            new Room { HotelId = hotels[2].Id, Type = RoomType.Double, CreatedAt = now, UpdatedAt = now },
            new Room { HotelId = hotels[2].Id, Type = RoomType.Deluxe, CreatedAt = now, UpdatedAt = now },
        };
        
        Context.Rooms.AddRange(rooms);
        Context.SaveChanges();

        var guests = new List<PrimaryGuest>
        {
            new PrimaryGuest
            {
                FirstName = "Alice",
                LastName = "Johnson",
                ContactNumber = "07384758473",
                AddressLine1 = "12 Main St",
                Town = "Springfield",
                PostCode = "SP1 2AA",
                CreatedAt = now,
                UpdatedAt = now
            },
            new PrimaryGuest
            {
                FirstName = "Bob",
                LastName = "Smith",
                ContactNumber = "07590690200",
                AddressLine1 = "34 Oak Rd",
                Town = "Rivertown",
                PostCode = "RT3 4BB",
                CreatedAt = now,
                UpdatedAt = now
            },
            new PrimaryGuest
            {
                FirstName = "Carol",
                LastName = "Ng",
                ContactNumber = "07384763542",
                AddressLine1 = "78 Pine Ave",
                Town = "Lakeside",
                PostCode = "LK5 6CC",
                CreatedAt = now,
                UpdatedAt = now
            }
        };
        
        Context.PrimaryGuests.AddRange(guests);
        Context.SaveChanges();

        var bookings = new List<Booking>
        {
            new Booking
            {
                RoomId = rooms[0].Id,
                PrimaryGuestId = guests[0].Id,
                CheckIn = new DateTime(2025, 4, 6),
                CheckOut = new DateTime(2025, 4, 8),
                BookingReference = "GP-0001",
                GuestCount = 1,
                CreatedAt = now,
                UpdatedAt = now
            },
            new Booking
            {
                RoomId = rooms[9].Id,
                PrimaryGuestId = guests[1].Id,
                CheckIn = new DateTime(2025, 10, 28),
                CheckOut = new DateTime(2025, 10, 30),
                BookingReference = "SR-0002",
                GuestCount = 3,
                CreatedAt = now,
                UpdatedAt = now
            },
            new Booking
            {
                RoomId = rooms[15].Id,
                PrimaryGuestId = guests[2].Id,
                CheckIn = new DateTime(2026, 2, 11),
                CheckOut = new DateTime(2026, 2, 14),
                BookingReference = "EGI-1001",
                GuestCount = 2,
                CreatedAt = now,
                UpdatedAt = now
            }
        };
        
        Context.Bookings.AddRange(bookings);
        Context.SaveChanges();
        return true;
    }

    public bool ResetDatabase()
    {
        Context.Bookings.RemoveRange(Context.Bookings);
        Context.Rooms.RemoveRange(Context.Rooms);
        Context.PrimaryGuests.RemoveRange(Context.PrimaryGuests);
        Context.Hotels.RemoveRange(Context.Hotels);
        Context.SaveChanges();
        return true;
    }
}