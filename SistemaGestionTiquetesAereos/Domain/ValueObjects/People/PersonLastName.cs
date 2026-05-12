using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.People;

public sealed record PersonLastName
{
    public string Value { get; }

    public PersonLastName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(PersonLastName), 100, 1, false);
    }

    public override string ToString() => Value;
}
