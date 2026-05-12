using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Aircraft;

public sealed record UpdateAircraftCommand(Guid Id, string RegistrationNumber,
    Guid AirlineId,
    Guid AircraftModelId,
    Guid AvailabilityStatusId,
    int TotalCapacity, bool IsActive) : IRequest;
