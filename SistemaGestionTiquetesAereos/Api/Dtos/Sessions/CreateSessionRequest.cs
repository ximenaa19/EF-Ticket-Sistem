namespace AirlineTicketSystem.Api.Dtos.Sessions;

public sealed record CreateSessionRequest(
    Guid UserId,
    string Token,
    DateTime ExpiresAt,
    DateTime? RevokedAt);
