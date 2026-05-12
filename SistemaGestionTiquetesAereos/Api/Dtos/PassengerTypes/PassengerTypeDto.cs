namespace AirlineTicketSystem.Api.Dtos.PassengerTypes;

public sealed record PassengerTypeDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
