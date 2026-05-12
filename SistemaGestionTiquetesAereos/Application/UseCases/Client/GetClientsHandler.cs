using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Client;

public sealed class GetClientsHandler : IRequestHandler<GetClientsQuery, IReadOnlyList<Domain.Entities.Client>>
{
    private readonly IClient _clientRepository;

    public GetClientsHandler(IClient clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Client>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        return _clientRepository.GetAllAsync(cancellationToken);
    }
}
