using AirlineTicketSystem.Domain.Entities;

namespace AirlineTicketSystem.Application.Abstractions;

public interface ISession : IRepository<Session>
{
    Task<bool> ExistsByTokenAsync(string token, Guid? excludeId = null, CancellationToken cancellationToken = default);
}
