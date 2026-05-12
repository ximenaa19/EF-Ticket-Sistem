using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class FlightSeatRepository : RepositoryBase<FlightSeat>, IFlightSeat
{
    public FlightSeatRepository(AppDbContext context)
        : base(context)
    {
    }
}
