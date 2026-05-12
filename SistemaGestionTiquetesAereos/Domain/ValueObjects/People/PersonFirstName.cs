using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.People;

public sealed record PersonFirstName
{
    public string Value { get; }

    public PersonFirstName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(PersonFirstName), 100, 1, false);
    }

    public override string ToString() => Value;
}
