using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightAssignment;

public sealed record GetFlightAssignmentsQuery : IRequest<IReadOnlyList<Domain.Entities.FlightAssignment>>;
