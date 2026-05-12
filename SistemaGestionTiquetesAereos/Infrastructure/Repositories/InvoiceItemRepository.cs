using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class InvoiceItemRepository : RepositoryBase<InvoiceItem>, IInvoiceItem
{
    public InvoiceItemRepository(AppDbContext context)
        : base(context)
    {
    }
}
