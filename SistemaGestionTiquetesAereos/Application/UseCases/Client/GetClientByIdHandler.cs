using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Client;

public sealed class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, Domain.Entities.Client>
{
    private readonly IClient _clientRepository;

    public GetClientByIdHandler(IClient clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<Domain.Entities.Client> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        return await _clientRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Client), request.Id);
    }
}
