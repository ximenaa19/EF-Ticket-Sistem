using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Routes;

public sealed record DistanceKilometers
{
    public decimal Value { get; }

    public DistanceKilometers(decimal value)
    {
        Value = ValueObjectGuards.NonNegative(value, nameof(DistanceKilometers));
    }
}
