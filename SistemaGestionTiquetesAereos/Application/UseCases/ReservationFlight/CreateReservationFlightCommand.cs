using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationFlight;

public sealed record CreateReservationFlightCommand(Guid ReservationId,
    Guid FlightId) : IRequest<Guid>;
