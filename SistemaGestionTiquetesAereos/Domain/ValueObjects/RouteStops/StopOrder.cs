using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.RouteStops;

public sealed record StopOrder
{
    public int Value { get; }

    public StopOrder(int value)
    {
        Value = ValueObjectGuards.NonNegative(value, nameof(StopOrder));
    }
}
