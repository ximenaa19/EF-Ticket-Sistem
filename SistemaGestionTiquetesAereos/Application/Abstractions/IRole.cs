using AirlineTicketSystem.Domain.Entities;

namespace AirlineTicketSystem.Application.Abstractions;

public interface IRole : IRepository<Role>
{
    Task<bool> ExistsByCodeAsync(string code, Guid? excludeId = null, CancellationToken cancellationToken = default);
}
