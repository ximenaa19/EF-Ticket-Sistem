using AirlineTicketSystem.Domain.Entities;

namespace AirlineTicketSystem.Application.Abstractions;

public interface IPhoneCode : IRepository<PhoneCode>
{
    Task<bool> ExistsByCodeAsync(string code, Guid? excludeId = null, CancellationToken cancellationToken = default);
}
