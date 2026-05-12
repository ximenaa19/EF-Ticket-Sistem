using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class StaffPositionRepository : RepositoryBase<StaffPosition>, IStaffPosition
{
    public StaffPositionRepository(AppDbContext context)
        : base(context)
    {
    }
    public Task<bool> ExistsByNameAsync(
        string name,
        Guid? excludeId = null,
        CancellationToken cancellationToken = default)
    {
        var normalizedValue = name.Trim();

        return Context.Set<StaffPosition>().AnyAsync(
            entity => entity.Name == normalizedValue && (!excludeId.HasValue || entity.Id != excludeId.Value),
            cancellationToken);
    }
}
