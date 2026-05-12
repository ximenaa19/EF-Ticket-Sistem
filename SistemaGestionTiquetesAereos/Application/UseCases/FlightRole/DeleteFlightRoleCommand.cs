using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightRole;

public sealed record DeleteFlightRoleCommand(Guid Id) : IRequest;
