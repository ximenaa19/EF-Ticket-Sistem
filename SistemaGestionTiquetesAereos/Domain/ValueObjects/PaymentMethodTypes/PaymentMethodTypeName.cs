using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.PaymentMethodTypes;

public sealed record PaymentMethodTypeName
{
    public string Value { get; }

    public PaymentMethodTypeName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(PaymentMethodTypeName), 80, 1, false);
    }

    public override string ToString() => Value;
}
