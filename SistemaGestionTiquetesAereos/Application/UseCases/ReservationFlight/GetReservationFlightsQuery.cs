using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationFlight;

public sealed record GetReservationFlightsQuery : IRequest<IReadOnlyList<Domain.Entities.ReservationFlight>>;
