using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class FlightAssignmentRepository : RepositoryBase<FlightAssignment>, IFlightAssignment
{
    public FlightAssignmentRepository(AppDbContext context)
        : base(context)
    {
    }
}
