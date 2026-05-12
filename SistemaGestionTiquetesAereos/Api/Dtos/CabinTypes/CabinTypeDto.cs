namespace AirlineTicketSystem.Api.Dtos.CabinTypes;

public sealed record CabinTypeDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
