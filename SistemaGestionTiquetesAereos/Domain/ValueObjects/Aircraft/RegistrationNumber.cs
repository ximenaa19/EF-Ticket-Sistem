using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Aircraft;

public sealed record RegistrationNumber
{
    public string Value { get; }

    public RegistrationNumber(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(RegistrationNumber), 30, 2, true);
    }

    public override string ToString() => Value;
}
