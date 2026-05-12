using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Session : BaseEntity
{
    private Session()
    {
        Token = string.Empty;
    }

    public Session(Guid userId, string token, DateTime expiresAt, DateTime? revokedAt)
    {
        Validate(userId, token, expiresAt, revokedAt);

        UserId = userId;
        Token = token.Trim();
        ExpiresAt = expiresAt;
        RevokedAt = revokedAt;
        IsActive = true;
    }

    public Guid UserId { get; private set; }
    public string Token { get; private set; }
    public DateTime ExpiresAt { get; private set; }
    public DateTime? RevokedAt { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid userId, string token, DateTime expiresAt, DateTime? revokedAt, bool isActive)
    {
        Validate(userId, token, expiresAt, revokedAt);

        UserId = userId;
        Token = token.Trim();
        ExpiresAt = expiresAt;
        RevokedAt = revokedAt;
        IsActive = isActive;

        MarkAsUpdated();
    }

    public void Activate()
    {
        IsActive = true;
        MarkAsUpdated();
    }

    public void Deactivate()
    {
        IsActive = false;
        MarkAsUpdated();
    }

    private static void Validate(Guid userId, string token, DateTime expiresAt, DateTime? revokedAt)
    {
        if (userId == Guid.Empty)
        {
            throw new InvalidDomainStateException("UserId is required.");
        }

        if (string.IsNullOrWhiteSpace(token))
        {
            throw new InvalidDomainStateException("Token is required.");
        }
        if (token.Trim().Length > 250)
        {
            throw new InvalidDomainStateException("Token cannot exceed 250 characters.");
        }
    }
}
