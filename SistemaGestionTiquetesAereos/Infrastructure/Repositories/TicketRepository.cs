using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class TicketRepository : RepositoryBase<Ticket>, ITicket
{
    public TicketRepository(AppDbContext context)
        : base(context)
    {
    }
    public Task<bool> ExistsByTicketNumberAsync(
        string ticketNumber,
        Guid? excludeId = null,
        CancellationToken cancellationToken = default)
    {
        var normalizedValue = ticketNumber.Trim();

        return Context.Set<Ticket>().AnyAsync(
            entity => entity.TicketNumber == normalizedValue && (!excludeId.HasValue || entity.Id != excludeId.Value),
            cancellationToken);
    }
}
