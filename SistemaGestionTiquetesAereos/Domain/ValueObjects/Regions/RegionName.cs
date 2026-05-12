using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Regions;

public sealed record RegionName
{
    public string Value { get; }

    public RegionName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(RegionName), 100, 1, false);
    }

    public override string ToString() => Value;
}
