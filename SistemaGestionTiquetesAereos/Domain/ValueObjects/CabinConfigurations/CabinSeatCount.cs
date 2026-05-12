using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.CabinConfigurations;

public sealed record CabinSeatCount
{
    public int Value { get; }

    public CabinSeatCount(int value)
    {
        Value = ValueObjectGuards.Positive(value, nameof(CabinSeatCount));
    }
}
