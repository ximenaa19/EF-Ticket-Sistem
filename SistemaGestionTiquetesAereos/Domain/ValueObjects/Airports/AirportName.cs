using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Airports;

public sealed record AirportName
{
    public string Value { get; }

    public AirportName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(AirportName), 150, 1, false);
    }

    public override string ToString() => Value;
}
