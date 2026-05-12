namespace AirlineTicketSystem.Api.Dtos.PaymentMethods;

public sealed record UpdatePaymentMethodRequest(
    Guid ClientId,
    Guid PaymentMethodTypeId,
    Guid? CardIssuerId,
    Guid? CardTypeId,
    string? MaskedNumber,
    bool IsActive);
