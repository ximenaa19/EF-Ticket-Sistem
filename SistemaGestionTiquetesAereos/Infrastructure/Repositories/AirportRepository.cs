using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class AirportRepository : RepositoryBase<Airport>, IAirport
{
    public AirportRepository(AppDbContext context)
        : base(context)
    {
    }
    public Task<bool> ExistsByIataCodeAsync(
        string iataCode,
        Guid? excludeId = null,
        CancellationToken cancellationToken = default)
    {
        var normalizedValue = iataCode.Trim();

        return Context.Set<Airport>().AnyAsync(
            entity => entity.IataCode == normalizedValue && (!excludeId.HasValue || entity.Id != excludeId.Value),
            cancellationToken);
    }
}
