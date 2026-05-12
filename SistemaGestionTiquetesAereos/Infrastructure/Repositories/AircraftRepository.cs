using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class AircraftRepository : RepositoryBase<Aircraft>, IAircraft
{
    public AircraftRepository(AppDbContext context)
        : base(context)
    {
    }
    public Task<bool> ExistsByRegistrationNumberAsync(
        string registrationNumber,
        Guid? excludeId = null,
        CancellationToken cancellationToken = default)
    {
        var normalizedValue = registrationNumber.Trim();

        return Context.Set<Aircraft>().AnyAsync(
            entity => entity.RegistrationNumber == normalizedValue && (!excludeId.HasValue || entity.Id != excludeId.Value),
            cancellationToken);
    }
}
