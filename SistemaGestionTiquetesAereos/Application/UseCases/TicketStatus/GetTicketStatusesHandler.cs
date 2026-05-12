using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.TicketStatus;

public sealed class GetTicketStatusesHandler : IRequestHandler<GetTicketStatusesQuery, IReadOnlyList<Domain.Entities.TicketStatus>>
{
    private readonly ITicketStatus _ticketStatusRepository;

    public GetTicketStatusesHandler(ITicketStatus ticketStatusRepository)
    {
        _ticketStatusRepository = ticketStatusRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.TicketStatus>> Handle(GetTicketStatusesQuery request, CancellationToken cancellationToken)
    {
        return _ticketStatusRepository.GetAllAsync(cancellationToken);
    }
}
