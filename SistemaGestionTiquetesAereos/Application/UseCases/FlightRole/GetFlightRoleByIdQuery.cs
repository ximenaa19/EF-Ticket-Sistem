using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightRole;

public sealed record GetFlightRoleByIdQuery(Guid Id) : IRequest<Domain.Entities.FlightRole>;
