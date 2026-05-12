using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Reservation;

public sealed record UpdateReservationCommand(Guid Id, Guid ClientId,
    Guid ReservationStatusId,
    string ReservationCode,
    DateTime ReservedAt,
    decimal TotalAmount,
    string Currency, bool IsActive) : IRequest;
