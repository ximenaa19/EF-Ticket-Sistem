using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Tickets;

public sealed record TicketFareAmount
{
    public decimal Value { get; }

    public TicketFareAmount(decimal value)
    {
        Value = ValueObjectGuards.NonNegative(value, nameof(TicketFareAmount));
    }
}
