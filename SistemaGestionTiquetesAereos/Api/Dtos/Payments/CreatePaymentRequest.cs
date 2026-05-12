namespace AirlineTicketSystem.Api.Dtos.Payments;

public sealed record CreatePaymentRequest(
    Guid ReservationId,
    Guid PaymentMethodId,
    Guid PaymentStatusId,
    decimal Amount,
    string Currency,
    DateTime? PaidAt);
