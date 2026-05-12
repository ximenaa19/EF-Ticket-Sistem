using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class FlightRepository : RepositoryBase<Flight>, IFlight
{
    public FlightRepository(AppDbContext context)
        : base(context)
    {
    }
    public Task<bool> ExistsByFlightCodeAsync(
        string flightCode,
        Guid? excludeId = null,
        CancellationToken cancellationToken = default)
    {
        var normalizedValue = flightCode.Trim();

        return Context.Set<Flight>().AnyAsync(
            entity => entity.FlightCode == normalizedValue && (!excludeId.HasValue || entity.Id != excludeId.Value),
            cancellationToken);
    }
}
