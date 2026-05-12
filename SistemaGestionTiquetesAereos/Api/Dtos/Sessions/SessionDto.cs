namespace AirlineTicketSystem.Api.Dtos.Sessions;

public sealed record SessionDto(
    Guid Id,
    Guid UserId,
    string Token,
    DateTime ExpiresAt,
    DateTime? RevokedAt,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
