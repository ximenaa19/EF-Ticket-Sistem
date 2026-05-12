using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatusTransition;

public sealed record DeleteFlightStatusTransitionCommand(Guid Id) : IRequest;
