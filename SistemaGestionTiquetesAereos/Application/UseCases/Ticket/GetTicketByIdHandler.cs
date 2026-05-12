using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Ticket;

public sealed class GetTicketByIdHandler : IRequestHandler<GetTicketByIdQuery, Domain.Entities.Ticket>
{
    private readonly ITicket _ticketRepository;

    public GetTicketByIdHandler(ITicket ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<Domain.Entities.Ticket> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        return await _ticketRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Ticket), request.Id);
    }
}
