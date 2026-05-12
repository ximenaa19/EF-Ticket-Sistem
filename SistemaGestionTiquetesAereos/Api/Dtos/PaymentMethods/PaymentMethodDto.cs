namespace AirlineTicketSystem.Api.Dtos.PaymentMethods;

public sealed record PaymentMethodDto(
    Guid Id,
    Guid ClientId,
    Guid PaymentMethodTypeId,
    Guid? CardIssuerId,
    Guid? CardTypeId,
    string? MaskedNumber,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
