namespace AirlineTicketSystem.Api.Dtos.Payments;

public sealed record PaymentDto(
    Guid Id,
    Guid ReservationId,
    Guid PaymentMethodId,
    Guid PaymentStatusId,
    decimal Amount,
    string Currency,
    DateTime? PaidAt,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
