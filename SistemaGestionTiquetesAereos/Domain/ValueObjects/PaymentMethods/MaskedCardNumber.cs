using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.PaymentMethods;

public sealed record MaskedCardNumber
{
    public string Value { get; }

    public MaskedCardNumber(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(MaskedCardNumber), 30, 1, false);
    }

    public override string ToString() => Value;
}
