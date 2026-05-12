namespace AirlineTicketSystem.Api.Dtos.ReservationPassengers;

public sealed record ReservationPassengerDto(
    Guid Id,
    Guid ReservationId,
    Guid PassengerId,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
