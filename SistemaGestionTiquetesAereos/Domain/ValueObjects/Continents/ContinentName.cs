using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Continents;

public sealed record ContinentName
{
    public string Value { get; }

    public ContinentName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(ContinentName), 100, 1, false);
    }

    public override string ToString() => Value;
}
