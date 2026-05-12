using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class RoleRepository : RepositoryBase<Role>, IRole
{
    public RoleRepository(AppDbContext context)
        : base(context)
    {
    }
    public Task<bool> ExistsByCodeAsync(
        string code,
        Guid? excludeId = null,
        CancellationToken cancellationToken = default)
    {
        var normalizedValue = code.Trim();

        return Context.Set<Role>().AnyAsync(
            entity => entity.Code == normalizedValue && (!excludeId.HasValue || entity.Id != excludeId.Value),
            cancellationToken);
    }
}
