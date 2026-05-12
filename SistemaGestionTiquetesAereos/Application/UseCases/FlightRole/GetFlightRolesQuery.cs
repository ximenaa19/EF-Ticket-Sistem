using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightRole;

public sealed record GetFlightRolesQuery : IRequest<IReadOnlyList<Domain.Entities.FlightRole>>;
