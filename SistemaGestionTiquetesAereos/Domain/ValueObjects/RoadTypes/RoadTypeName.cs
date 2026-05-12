using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.RoadTypes;

public sealed record RoadTypeName
{
    public string Value { get; }

    public RoadTypeName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(RoadTypeName), 80, 1, false);
    }

    public override string ToString() => Value;
}
