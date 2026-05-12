namespace AirlineTicketSystem.Api.Dtos.CardTypes;

public sealed record CardTypeDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
