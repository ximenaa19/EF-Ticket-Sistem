namespace AirlineTicketSystem.Api.Dtos.Clients;

public sealed record ClientDto(
    Guid Id,
    Guid PersonId,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
