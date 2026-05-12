using AirlineTicketSystem.Domain.Entities;

namespace AirlineTicketSystem.Application.Abstractions;

public interface IAirline : IRepository<Airline>
{
    Task<bool> ExistsByIataCodeAsync(string iataCode, Guid? excludeId = null, CancellationToken cancellationToken = default);
}
