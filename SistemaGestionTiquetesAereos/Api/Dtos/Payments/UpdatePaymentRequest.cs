namespace AirlineTicketSystem.Api.Dtos.Payments;

public sealed record UpdatePaymentRequest(
    Guid ReservationId,
    Guid PaymentMethodId,
    Guid PaymentStatusId,
    decimal Amount,
    string Currency,
    DateTime? PaidAt,
    bool IsActive);
