using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Flights;

public sealed record FlightCapacity
{
    public int Value { get; }

    public FlightCapacity(int value)
    {
        Value = ValueObjectGuards.Positive(value, nameof(FlightCapacity));
    }
}
