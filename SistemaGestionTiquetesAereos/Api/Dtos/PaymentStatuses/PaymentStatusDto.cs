namespace AirlineTicketSystem.Api.Dtos.PaymentStatuses;

public sealed record PaymentStatusDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
