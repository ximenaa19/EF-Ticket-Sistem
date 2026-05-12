using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Session;

public sealed record UpdateSessionCommand(Guid Id, Guid UserId,
    string Token,
    DateTime ExpiresAt,
    DateTime? RevokedAt, bool IsActive) : IRequest;
