using AirlineTicketSystem.Domain.Entities;

namespace AirlineTicketSystem.Application.Abstractions;

public interface IReservation : IRepository<Reservation>
{
    Task<bool> ExistsByReservationCodeAsync(string reservationCode, Guid? excludeId = null, CancellationToken cancellationToken = default);
}
