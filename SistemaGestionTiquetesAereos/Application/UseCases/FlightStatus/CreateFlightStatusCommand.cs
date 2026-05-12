using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatus;

public sealed record CreateFlightStatusCommand(string Name) : IRequest<Guid>;
