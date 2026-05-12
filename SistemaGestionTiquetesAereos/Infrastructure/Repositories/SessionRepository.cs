using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class SessionRepository : RepositoryBase<Session>, ISession
{
    public SessionRepository(AppDbContext context)
        : base(context)
    {
    }
    public Task<bool> ExistsByTokenAsync(
        string token,
        Guid? excludeId = null,
        CancellationToken cancellationToken = default)
    {
        var normalizedValue = token.Trim();

        return Context.Set<Session>().AnyAsync(
            entity => entity.Token == normalizedValue && (!excludeId.HasValue || entity.Id != excludeId.Value),
            cancellationToken);
    }
}
