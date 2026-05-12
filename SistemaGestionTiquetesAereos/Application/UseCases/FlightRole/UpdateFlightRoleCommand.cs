using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightRole;

public sealed record UpdateFlightRoleCommand(Guid Id, string Name, bool IsActive) : IRequest;
