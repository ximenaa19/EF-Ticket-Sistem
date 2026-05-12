using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightAssignment;

public sealed record UpdateFlightAssignmentCommand(Guid Id, Guid FlightId,
    Guid StaffId,
    Guid FlightRoleId, bool IsActive) : IRequest;
