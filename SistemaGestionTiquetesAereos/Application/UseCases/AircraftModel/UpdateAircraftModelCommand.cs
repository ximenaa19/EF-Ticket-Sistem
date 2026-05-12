using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftModel;

public sealed record UpdateAircraftModelCommand(Guid Id, string Name,
    Guid AircraftManufacturerId, bool IsActive) : IRequest;
