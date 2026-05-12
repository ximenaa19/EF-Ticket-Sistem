using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.PersonPhones;

public sealed record PersonPhoneNumber
{
    public string Value { get; }

    public PersonPhoneNumber(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(PersonPhoneNumber), 30, 1, false);
    }

    public override string ToString() => Value;
}
