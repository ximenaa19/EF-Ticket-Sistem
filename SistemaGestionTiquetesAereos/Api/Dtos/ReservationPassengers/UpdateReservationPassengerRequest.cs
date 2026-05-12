namespace AirlineTicketSystem.Api.Dtos.ReservationPassengers;

public sealed record UpdateReservationPassengerRequest(
    Guid ReservationId,
    Guid PassengerId,
    bool IsActive);
