using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Aircraft;

public sealed record CreateAircraftCommand(string RegistrationNumber,
    Guid AirlineId,
    Guid AircraftModelId,
    Guid AvailabilityStatusId,
    int TotalCapacity) : IRequest<Guid>;
