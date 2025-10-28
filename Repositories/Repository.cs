using HotelBookingApi.Common;

namespace HotelBookingApi.Repositories;

public abstract class Repository
{
    protected readonly DatabaseContext Context;

    protected Repository(DatabaseContext context) => Context = context;
}