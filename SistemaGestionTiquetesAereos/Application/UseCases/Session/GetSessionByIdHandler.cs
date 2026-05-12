using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Session;

public sealed class GetSessionByIdHandler : IRequestHandler<GetSessionByIdQuery, Domain.Entities.Session>
{
    private readonly ISession _sessionRepository;

    public GetSessionByIdHandler(ISession sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<Domain.Entities.Session> Handle(GetSessionByIdQuery request, CancellationToken cancellationToken)
    {
        return await _sessionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Session), request.Id);
    }
}
