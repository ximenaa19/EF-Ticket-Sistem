namespace AirlineTicketSystem.Api.Dtos.CardIssuers;

public sealed record UpdateCardIssuerRequest(
    string Name,
    bool IsActive);
