using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftModel;

public sealed class GetAircraftModelByIdHandler : IRequestHandler<GetAircraftModelByIdQuery, Domain.Entities.AircraftModel>
{
    private readonly IAircraftModel _aircraftModelRepository;

    public GetAircraftModelByIdHandler(IAircraftModel aircraftModelRepository)
    {
        _aircraftModelRepository = aircraftModelRepository;
    }

    public async Task<Domain.Entities.AircraftModel> Handle(GetAircraftModelByIdQuery request, CancellationToken cancellationToken)
    {
        return await _aircraftModelRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.AircraftModel), request.Id);
    }
}
