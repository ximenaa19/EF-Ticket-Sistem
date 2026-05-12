using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Countries;

public sealed record CountryIsoCode
{
    public string Value { get; }

    public CountryIsoCode(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(CountryIsoCode), 3, 2, true);
    }

    public override string ToString() => Value;
}
