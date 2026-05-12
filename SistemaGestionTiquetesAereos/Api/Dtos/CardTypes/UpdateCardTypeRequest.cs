namespace AirlineTicketSystem.Api.Dtos.CardTypes;

public sealed record UpdateCardTypeRequest(
    string Name,
    bool IsActive);
