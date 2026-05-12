namespace AirlineTicketSystem.Api.Dtos.EmailDomains;

public sealed record UpdateEmailDomainRequest(
    string Name,
    bool IsActive);
