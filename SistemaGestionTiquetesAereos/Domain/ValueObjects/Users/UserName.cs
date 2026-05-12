using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Users;

public sealed record UserName
{
    public string Value { get; }

    public UserName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(UserName), 80, 1, false);
    }

    public override string ToString() => Value;
}
