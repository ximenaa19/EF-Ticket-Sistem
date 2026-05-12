using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatusTransition;

public sealed record UpdateFlightStatusTransitionCommand(Guid Id, Guid FlightId,
    Guid FromFlightStatusId,
    Guid ToFlightStatusId,
    DateTime ChangedAt, bool IsActive) : IRequest;
