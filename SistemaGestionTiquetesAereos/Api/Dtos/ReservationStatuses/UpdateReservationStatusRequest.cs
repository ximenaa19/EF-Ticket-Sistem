namespace AirlineTicketSystem.Api.Dtos.ReservationStatuses;

public sealed record UpdateReservationStatusRequest(
    string Name,
    bool IsActive);
