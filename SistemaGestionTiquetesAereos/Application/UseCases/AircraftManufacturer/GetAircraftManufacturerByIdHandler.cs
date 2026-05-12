using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftManufacturer;

public sealed class GetAircraftManufacturerByIdHandler : IRequestHandler<GetAircraftManufacturerByIdQuery, Domain.Entities.AircraftManufacturer>
{
    private readonly IAircraftManufacturer _aircraftManufacturerRepository;

    public GetAircraftManufacturerByIdHandler(IAircraftManufacturer aircraftManufacturerRepository)
    {
        _aircraftManufacturerRepository = aircraftManufacturerRepository;
    }

    public async Task<Domain.Entities.AircraftManufacturer> Handle(GetAircraftManufacturerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _aircraftManufacturerRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.AircraftManufacturer), request.Id);
    }
}
