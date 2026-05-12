using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Cities;

public sealed record CityName
{
    public string Value { get; }

    public CityName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(CityName), 120, 1, false);
    }

    public override string ToString() => Value;
}
