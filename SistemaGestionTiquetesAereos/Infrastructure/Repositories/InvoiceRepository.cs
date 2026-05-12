using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class InvoiceRepository : RepositoryBase<Invoice>, IInvoice
{
    public InvoiceRepository(AppDbContext context)
        : base(context)
    {
    }
    public Task<bool> ExistsByInvoiceNumberAsync(
        string invoiceNumber,
        Guid? excludeId = null,
        CancellationToken cancellationToken = default)
    {
        var normalizedValue = invoiceNumber.Trim();

        return Context.Set<Invoice>().AnyAsync(
            entity => entity.InvoiceNumber == normalizedValue && (!excludeId.HasValue || entity.Id != excludeId.Value),
            cancellationToken);
    }
}
