namespace AirlineTicketSystem.Api.Dtos.PersonEmails;

public sealed record PersonEmailDto(
    Guid Id,
    Guid PersonId,
    Guid EmailDomainId,
    string LocalPart,
    bool IsPrimary,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
