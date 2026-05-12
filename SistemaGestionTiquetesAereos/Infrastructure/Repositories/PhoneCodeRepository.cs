using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class PhoneCodeRepository : RepositoryBase<PhoneCode>, IPhoneCode
{
    public PhoneCodeRepository(AppDbContext context)
        : base(context)
    {
    }
    public Task<bool> ExistsByCodeAsync(
        string code,
        Guid? excludeId = null,
        CancellationToken cancellationToken = default)
    {
        var normalizedValue = code.Trim();

        return Context.Set<PhoneCode>().AnyAsync(
            entity => entity.Code == normalizedValue && (!excludeId.HasValue || entity.Id != excludeId.Value),
            cancellationToken);
    }
}
