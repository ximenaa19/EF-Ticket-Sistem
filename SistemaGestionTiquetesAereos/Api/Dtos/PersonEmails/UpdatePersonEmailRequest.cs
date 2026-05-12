namespace AirlineTicketSystem.Api.Dtos.PersonEmails;

public sealed record UpdatePersonEmailRequest(
    Guid PersonId,
    Guid EmailDomainId,
    string LocalPart,
    bool IsPrimary,
    bool IsActive);
