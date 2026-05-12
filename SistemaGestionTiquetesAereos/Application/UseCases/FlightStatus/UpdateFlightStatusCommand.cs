using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatus;

public sealed record UpdateFlightStatusCommand(Guid Id, string Name, bool IsActive) : IRequest;
