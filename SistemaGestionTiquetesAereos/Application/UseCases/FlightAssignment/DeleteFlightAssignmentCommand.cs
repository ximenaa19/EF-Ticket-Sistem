using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightAssignment;

public sealed record DeleteFlightAssignmentCommand(Guid Id) : IRequest;
