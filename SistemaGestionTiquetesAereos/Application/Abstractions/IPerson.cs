using AirlineTicketSystem.Domain.Entities;

namespace AirlineTicketSystem.Application.Abstractions;

public interface IPerson : IRepository<Person>
{
    Task<bool> ExistsByDocumentNumberAsync(string documentNumber, Guid? excludeId = null, CancellationToken cancellationToken = default);
}
