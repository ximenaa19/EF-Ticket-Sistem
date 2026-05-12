using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftManufacturer;

public sealed class GetAircraftManufacturersHandler : IRequestHandler<GetAircraftManufacturersQuery, IReadOnlyList<Domain.Entities.AircraftManufacturer>>
{
    private readonly IAircraftManufacturer _aircraftManufacturerRepository;

    public GetAircraftManufacturersHandler(IAircraftManufacturer aircraftManufacturerRepository)
    {
        _aircraftManufacturerRepository = aircraftManufacturerRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.AircraftManufacturer>> Handle(GetAircraftManufacturersQuery request, CancellationToken cancellationToken)
    {
        return _aircraftManufacturerRepository.GetAllAsync(cancellationToken);
    }
}
