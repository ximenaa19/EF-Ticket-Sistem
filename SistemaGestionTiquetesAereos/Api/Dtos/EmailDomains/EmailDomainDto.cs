namespace AirlineTicketSystem.Api.Dtos.EmailDomains;

public sealed record EmailDomainDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
