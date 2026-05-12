namespace AirlineTicketSystem.Api.Dtos.PaymentMethodTypes;

public sealed record PaymentMethodTypeDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
