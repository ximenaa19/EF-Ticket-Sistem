using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationFlight;

public sealed record DeleteReservationFlightCommand(Guid Id) : IRequest;
