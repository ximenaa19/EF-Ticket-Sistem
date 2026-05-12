using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.TicketStatuses;

public sealed record TicketStatusName
{
    public string Value { get; }

    public TicketStatusName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(TicketStatusName), 80, 1, false);
    }

    public override string ToString() => Value;
}
