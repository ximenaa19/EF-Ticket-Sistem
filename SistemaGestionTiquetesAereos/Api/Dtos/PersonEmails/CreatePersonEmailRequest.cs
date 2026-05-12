namespace AirlineTicketSystem.Api.Dtos.PersonEmails;

public sealed record CreatePersonEmailRequest(
    Guid PersonId,
    Guid EmailDomainId,
    string LocalPart,
    bool IsPrimary);
