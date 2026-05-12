using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationFlight;

public sealed record GetReservationFlightByIdQuery(Guid Id) : IRequest<Domain.Entities.ReservationFlight>;
