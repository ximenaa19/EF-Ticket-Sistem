using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightAssignment;

public sealed record CreateFlightAssignmentCommand(Guid FlightId,
    Guid StaffId,
    Guid FlightRoleId) : IRequest<Guid>;
