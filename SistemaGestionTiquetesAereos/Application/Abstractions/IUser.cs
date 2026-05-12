using AirlineTicketSystem.Domain.Entities;

namespace AirlineTicketSystem.Application.Abstractions;

public interface IUser : IRepository<User>
{
    Task<bool> ExistsByUserNameAsync(string userName, Guid? excludeId = null, CancellationToken cancellationToken = default);
}
