using AirlineTicketSystem.Domain.Entities;

namespace AirlineTicketSystem.Application.Abstractions;

public interface IAirport : IRepository<Airport>
{
    Task<bool> ExistsByIataCodeAsync(string iataCode, Guid? excludeId = null, CancellationToken cancellationToken = default);
}
