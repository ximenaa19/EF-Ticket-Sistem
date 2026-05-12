using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftModel;

public sealed record CreateAircraftModelCommand(string Name,
    Guid AircraftManufacturerId) : IRequest<Guid>;
