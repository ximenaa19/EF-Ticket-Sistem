using AirlineTicketSystem.Domain.Entities;

namespace AirlineTicketSystem.Application.Abstractions;

public interface IReservationStatus : IRepository<ReservationStatus>
{
    Task<bool> ExistsByNameAsync(string name, Guid? excludeId = null, CancellationToken cancellationToken = default);
}
