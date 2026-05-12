using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatus;

public sealed record DeleteFlightStatusCommand(Guid Id) : IRequest;
