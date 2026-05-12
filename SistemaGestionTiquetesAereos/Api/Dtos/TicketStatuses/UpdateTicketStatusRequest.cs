namespace AirlineTicketSystem.Api.Dtos.TicketStatuses;

public sealed record UpdateTicketStatusRequest(
    string Name,
    bool IsActive);
