namespace AirlineTicketSystem.Api.Dtos.PaymentMethods;

public sealed record CreatePaymentMethodRequest(
    Guid ClientId,
    Guid PaymentMethodTypeId,
    Guid? CardIssuerId,
    Guid? CardTypeId,
    string? MaskedNumber);
