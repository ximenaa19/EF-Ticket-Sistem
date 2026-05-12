using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationFlight;

public sealed record UpdateReservationFlightCommand(Guid Id, Guid ReservationId,
    Guid FlightId, bool IsActive) : IRequest;
