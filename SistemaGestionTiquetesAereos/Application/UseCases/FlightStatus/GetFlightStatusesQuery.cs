using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatus;

public sealed record GetFlightStatusesQuery : IRequest<IReadOnlyList<Domain.Entities.FlightStatus>>;
