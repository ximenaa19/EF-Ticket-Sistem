using AirlineTicketSystem.Domain.Entities;

namespace AirlineTicketSystem.Application.Abstractions;

public interface ITicket : IRepository<Ticket>
{
    Task<bool> ExistsByTicketNumberAsync(string ticketNumber, Guid? excludeId = null, CancellationToken cancellationToken = default);
}
