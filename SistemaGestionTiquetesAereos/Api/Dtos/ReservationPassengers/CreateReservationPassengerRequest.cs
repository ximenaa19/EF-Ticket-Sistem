namespace AirlineTicketSystem.Api.Dtos.ReservationPassengers;

public sealed record CreateReservationPassengerRequest(
    Guid ReservationId,
    Guid PassengerId);
