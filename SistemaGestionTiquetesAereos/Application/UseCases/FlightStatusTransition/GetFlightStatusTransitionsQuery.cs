using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatusTransition;

public sealed record GetFlightStatusTransitionsQuery : IRequest<IReadOnlyList<Domain.Entities.FlightStatusTransition>>;
