using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Users;

public sealed record PasswordHash
{
    public string Value { get; }

    public PasswordHash(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(PasswordHash), 250, 1, false);
    }

    public override string ToString() => Value;
}
