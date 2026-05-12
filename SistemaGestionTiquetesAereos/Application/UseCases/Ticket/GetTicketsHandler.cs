using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Ticket;

public sealed class GetTicketsHandler : IRequestHandler<GetTicketsQuery, IReadOnlyList<Domain.Entities.Ticket>>
{
    private readonly ITicket _ticketRepository;

    public GetTicketsHandler(ITicket ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Ticket>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
    {
        return _ticketRepository.GetAllAsync(cancellationToken);
    }
}
