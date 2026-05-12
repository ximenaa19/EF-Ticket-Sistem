using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightSeat;

public sealed record GetFlightSeatsQuery : IRequest<IReadOnlyList<Domain.Entities.FlightSeat>>;
