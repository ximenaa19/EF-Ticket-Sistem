namespace AirlineTicketSystem.Api.Dtos.DocumentTypes;

public sealed record DocumentTypeDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
