namespace AirlineTicketSystem.Api.Dtos.CardIssuers;

public sealed record CardIssuerDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
