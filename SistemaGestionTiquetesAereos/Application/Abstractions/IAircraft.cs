using AirlineTicketSystem.Domain.Entities;

namespace AirlineTicketSystem.Application.Abstractions;

public interface IAircraft : IRepository<Aircraft>
{
    Task<bool> ExistsByRegistrationNumberAsync(string registrationNumber, Guid? excludeId = null, CancellationToken cancellationToken = default);
}
