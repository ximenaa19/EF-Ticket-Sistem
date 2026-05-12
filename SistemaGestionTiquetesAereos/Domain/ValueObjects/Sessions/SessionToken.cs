using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Sessions;

public sealed record SessionToken
{
    public string Value { get; }

    public SessionToken(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(SessionToken), 250, 1, false);
    }

    public override string ToString() => Value;
}
