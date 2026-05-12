using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class StaffRepository : RepositoryBase<Staff>, IStaff
{
    public StaffRepository(AppDbContext context)
        : base(context)
    {
    }
    public Task<bool> ExistsByEmployeeCodeAsync(
        string employeeCode,
        Guid? excludeId = null,
        CancellationToken cancellationToken = default)
    {
        var normalizedValue = employeeCode.Trim();

        return Context.Set<Staff>().AnyAsync(
            entity => entity.EmployeeCode == normalizedValue && (!excludeId.HasValue || entity.Id != excludeId.Value),
            cancellationToken);
    }
}
