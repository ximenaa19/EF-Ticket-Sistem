namespace AirlineTicketSystem.Api.Dtos.Airlines;

public sealed record AirlineDto(
    Guid Id,
    string Name,
    string IataCode,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
