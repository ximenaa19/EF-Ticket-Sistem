using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.PassengerTypes;

public sealed record PassengerTypeName
{
    public string Value { get; }

    public PassengerTypeName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(PassengerTypeName), 80, 1, false);
    }

    public override string ToString() => Value;
}
