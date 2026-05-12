using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Reservation;

public sealed record CreateReservationCommand(Guid ClientId,
    Guid ReservationStatusId,
    string ReservationCode,
    DateTime ReservedAt,
    decimal TotalAmount,
    string Currency) : IRequest<Guid>;
