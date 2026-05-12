using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftModel;

public sealed class GetAircraftModelsHandler : IRequestHandler<GetAircraftModelsQuery, IReadOnlyList<Domain.Entities.AircraftModel>>
{
    private readonly IAircraftModel _aircraftModelRepository;

    public GetAircraftModelsHandler(IAircraftModel aircraftModelRepository)
    {
        _aircraftModelRepository = aircraftModelRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.AircraftModel>> Handle(GetAircraftModelsQuery request, CancellationToken cancellationToken)
    {
        return _aircraftModelRepository.GetAllAsync(cancellationToken);
    }
}
