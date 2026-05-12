using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class ReservationFlightRepository : RepositoryBase<ReservationFlight>, IReservationFlight
{
    public ReservationFlightRepository(AppDbContext context)
        : base(context)
    {
    }
}
