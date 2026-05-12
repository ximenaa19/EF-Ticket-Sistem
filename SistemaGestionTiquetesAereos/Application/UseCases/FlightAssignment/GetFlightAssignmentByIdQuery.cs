using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightAssignment;

public sealed record GetFlightAssignmentByIdQuery(Guid Id) : IRequest<Domain.Entities.FlightAssignment>;
