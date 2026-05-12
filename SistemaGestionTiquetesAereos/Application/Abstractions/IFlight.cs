using AirlineTicketSystem.Domain.Entities;

namespace AirlineTicketSystem.Application.Abstractions;

public interface IFlight : IRepository<Flight>
{
    Task<bool> ExistsByFlightCodeAsync(string flightCode, Guid? excludeId = null, CancellationToken cancellationToken = default);
}
