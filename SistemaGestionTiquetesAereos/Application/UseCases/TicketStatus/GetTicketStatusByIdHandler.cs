using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.TicketStatus;

public sealed class GetTicketStatusByIdHandler : IRequestHandler<GetTicketStatusByIdQuery, Domain.Entities.TicketStatus>
{
    private readonly ITicketStatus _ticketStatusRepository;

    public GetTicketStatusByIdHandler(ITicketStatus ticketStatusRepository)
    {
        _ticketStatusRepository = ticketStatusRepository;
    }

    public async Task<Domain.Entities.TicketStatus> Handle(GetTicketStatusByIdQuery request, CancellationToken cancellationToken)
    {
        return await _ticketStatusRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.TicketStatus), request.Id);
    }
}
