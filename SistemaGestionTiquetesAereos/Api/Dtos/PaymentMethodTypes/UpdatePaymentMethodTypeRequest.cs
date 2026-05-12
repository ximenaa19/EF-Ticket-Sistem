namespace AirlineTicketSystem.Api.Dtos.PaymentMethodTypes;

public sealed record UpdatePaymentMethodTypeRequest(
    string Name,
    bool IsActive);
