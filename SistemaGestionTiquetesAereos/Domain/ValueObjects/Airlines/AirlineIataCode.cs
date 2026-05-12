using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Airlines;

public sealed record AirlineIataCode
{
    public string Value { get; }

    public AirlineIataCode(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(AirlineIataCode), 3, 2, true);
    }

    public override string ToString() => Value;
}
