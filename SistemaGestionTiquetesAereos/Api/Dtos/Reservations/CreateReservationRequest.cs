namespace AirlineTicketSystem.Api.Dtos.Reservations;

public sealed record CreateReservationRequest(
    Guid ClientId,
    Guid ReservationStatusId,
    string ReservationCode,
    DateTime ReservedAt,
    decimal TotalAmount,
    string Currency);
