namespace AirlineTicketSystem.Api.Dtos.StaffPositions;

public sealed record StaffPositionDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
