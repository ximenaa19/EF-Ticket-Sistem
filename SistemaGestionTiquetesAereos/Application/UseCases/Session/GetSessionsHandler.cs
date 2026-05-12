using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Session;

public sealed class GetSessionsHandler : IRequestHandler<GetSessionsQuery, IReadOnlyList<Domain.Entities.Session>>
{
    private readonly ISession _sessionRepository;

    public GetSessionsHandler(ISession sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Session>> Handle(GetSessionsQuery request, CancellationToken cancellationToken)
    {
        return _sessionRepository.GetAllAsync(cancellationToken);
    }
}
