using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.PhoneCodes;

public sealed record PhoneCodeValue
{
    public string Value { get; }

    public PhoneCodeValue(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(PhoneCodeValue), 10, 1, false);
    }

    public override string ToString() => Value;
}
