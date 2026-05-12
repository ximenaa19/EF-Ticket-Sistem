using AirlineTicketSystem.Domain.Entities;

namespace AirlineTicketSystem.Application.Abstractions;

public interface IInvoice : IRepository<Invoice>
{
    Task<bool> ExistsByInvoiceNumberAsync(string invoiceNumber, Guid? excludeId = null, CancellationToken cancellationToken = default);
}
