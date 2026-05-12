using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Payments;

public sealed record PaymentAmount
{
    public decimal Value { get; }

    public PaymentAmount(decimal value)
    {
        Value = ValueObjectGuards.NonNegative(value, nameof(PaymentAmount));
    }
}
