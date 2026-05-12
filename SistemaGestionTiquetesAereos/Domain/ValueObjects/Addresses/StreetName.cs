using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Addresses;

public sealed record StreetName
{
    public string Value { get; }

    public StreetName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(StreetName), 150, 1, false);
    }

    public override string ToString() => Value;
}
