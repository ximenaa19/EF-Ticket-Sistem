using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class FlightStatusTransitionRepository : RepositoryBase<FlightStatusTransition>, IFlightStatusTransition
{
    public FlightStatusTransitionRepository(AppDbContext context)
        : base(context)
    {
    }
}
