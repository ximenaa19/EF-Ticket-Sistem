using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class TicketStatusRepository : RepositoryBase<TicketStatus>, ITicketStatus
{
    public TicketStatusRepository(AppDbContext context)
        : base(context)
    {
    }
    public Task<bool> ExistsByNameAsync(
        string name,
        Guid? excludeId = null,
        CancellationToken cancellationToken = default)
    {
        var normalizedValue = name.Trim();

        return Context.Set<TicketStatus>().AnyAsync(
            entity => entity.Name == normalizedValue && (!excludeId.HasValue || entity.Id != excludeId.Value),
            cancellationToken);
    }
}
