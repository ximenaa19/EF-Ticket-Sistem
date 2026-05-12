using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class ReservationRepository : RepositoryBase<Reservation>, IReservation
{
    public ReservationRepository(AppDbContext context)
        : base(context)
    {
    }
    public Task<bool> ExistsByReservationCodeAsync(
        string reservationCode,
        Guid? excludeId = null,
        CancellationToken cancellationToken = default)
    {
        var normalizedValue = reservationCode.Trim();

        return Context.Set<Reservation>().AnyAsync(
            entity => entity.ReservationCode == normalizedValue && (!excludeId.HasValue || entity.Id != excludeId.Value),
            cancellationToken);
    }
}
