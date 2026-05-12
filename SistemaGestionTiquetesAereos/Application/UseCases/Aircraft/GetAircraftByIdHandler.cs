using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Aircraft;

public sealed class GetAircraftByIdHandler : IRequestHandler<GetAircraftByIdQuery, Domain.Entities.Aircraft>
{
    private readonly IAircraft _aircraftRepository;

    public GetAircraftByIdHandler(IAircraft aircraftRepository)
    {
        _aircraftRepository = aircraftRepository;
    }

    public async Task<Domain.Entities.Aircraft> Handle(GetAircraftByIdQuery request, CancellationToken cancellationToken)
    {
        return await _aircraftRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Aircraft), request.Id);
    }
}
