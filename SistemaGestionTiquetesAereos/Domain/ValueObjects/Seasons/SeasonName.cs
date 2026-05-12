using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Seasons;

public sealed record SeasonName
{
    public string Value { get; }

    public SeasonName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(SeasonName), 80, 1, false);
    }

    public override string ToString() => Value;
}
