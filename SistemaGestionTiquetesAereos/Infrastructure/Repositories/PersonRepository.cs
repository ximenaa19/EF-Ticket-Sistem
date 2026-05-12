using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class PersonRepository : RepositoryBase<Person>, IPerson
{
    public PersonRepository(AppDbContext context)
        : base(context)
    {
    }
    public Task<bool> ExistsByDocumentNumberAsync(
        string documentNumber,
        Guid? excludeId = null,
        CancellationToken cancellationToken = default)
    {
        var normalizedValue = documentNumber.Trim();

        return Context.Set<Person>().AnyAsync(
            entity => entity.DocumentNumber == normalizedValue && (!excludeId.HasValue || entity.Id != excludeId.Value),
            cancellationToken);
    }
}
