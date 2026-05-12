using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Tickets;

public sealed record TicketNumber
{
    public string Value { get; }

    public TicketNumber(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(TicketNumber), 40, 2, true);
    }

    public override string ToString() => Value;
}
