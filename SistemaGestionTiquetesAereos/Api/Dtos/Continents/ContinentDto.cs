namespace AirlineTicketSystem.Api.Dtos.Continents;

public sealed record ContinentDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
