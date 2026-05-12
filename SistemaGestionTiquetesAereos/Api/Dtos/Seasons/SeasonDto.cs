namespace AirlineTicketSystem.Api.Dtos.Seasons;

public sealed record SeasonDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
