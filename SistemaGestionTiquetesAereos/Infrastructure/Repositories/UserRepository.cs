using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class UserRepository : RepositoryBase<User>, IUser
{
    public UserRepository(AppDbContext context)
        : base(context)
    {
    }
    public Task<bool> ExistsByUserNameAsync(
        string userName,
        Guid? excludeId = null,
        CancellationToken cancellationToken = default)
    {
        var normalizedValue = userName.Trim();

        return Context.Set<User>().AnyAsync(
            entity => entity.UserName == normalizedValue && (!excludeId.HasValue || entity.Id != excludeId.Value),
            cancellationToken);
    }
}
