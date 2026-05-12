using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatusTransition;

public sealed record CreateFlightStatusTransitionCommand(Guid FlightId,
    Guid FromFlightStatusId,
    Guid ToFlightStatusId,
    DateTime ChangedAt) : IRequest<Guid>;
