using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.CardTypes;

public sealed record CardTypeName
{
    public string Value { get; }

    public CardTypeName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(CardTypeName), 80, 1, false);
    }

    public override string ToString() => Value;
}
