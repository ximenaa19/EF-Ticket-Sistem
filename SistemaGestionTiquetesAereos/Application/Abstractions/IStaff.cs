using AirlineTicketSystem.Domain.Entities;

namespace AirlineTicketSystem.Application.Abstractions;

public interface IStaff : IRepository<Staff>
{
    Task<bool> ExistsByEmployeeCodeAsync(string employeeCode, Guid? excludeId = null, CancellationToken cancellationToken = default);
}
