using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Flights;

public sealed record AvailableSeatCount
{
    public int Value { get; }

    public AvailableSeatCount(int value)
    {
        Value = ValueObjectGuards.NonNegative(value, nameof(AvailableSeatCount));
    }
}
