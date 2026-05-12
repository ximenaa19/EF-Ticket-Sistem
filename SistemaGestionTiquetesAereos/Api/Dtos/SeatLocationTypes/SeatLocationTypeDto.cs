namespace AirlineTicketSystem.Api.Dtos.SeatLocationTypes;

public sealed record SeatLocationTypeDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
