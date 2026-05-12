using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Countries;

public sealed record CountryName
{
    public string Value { get; }

    public CountryName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(CountryName), 100, 1, false);
    }

    public override string ToString() => Value;
}
