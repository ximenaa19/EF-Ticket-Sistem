using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Fares;

public sealed record FareAmount
{
    public decimal Value { get; }

    public FareAmount(decimal value)
    {
        Value = ValueObjectGuards.NonNegative(value, nameof(FareAmount));
    }
}
