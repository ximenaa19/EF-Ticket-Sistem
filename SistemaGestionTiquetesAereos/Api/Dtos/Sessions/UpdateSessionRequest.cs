namespace AirlineTicketSystem.Api.Dtos.Sessions;

public sealed record UpdateSessionRequest(
    Guid UserId,
    string Token,
    DateTime ExpiresAt,
    DateTime? RevokedAt,
    bool IsActive);
