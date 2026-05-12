using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightRole;

public sealed record CreateFlightRoleCommand(string Name) : IRequest<Guid>;
