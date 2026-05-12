namespace AirlineTicketSystem.Api.Dtos.TicketStatuses;

public sealed record TicketStatusDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
