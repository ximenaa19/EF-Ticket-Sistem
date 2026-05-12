namespace AirlineTicketSystem.Api.Dtos.PaymentStatuses;

public sealed record UpdatePaymentStatusRequest(
    string Name,
    bool IsActive);
