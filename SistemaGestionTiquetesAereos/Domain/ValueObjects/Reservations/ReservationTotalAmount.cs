using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Reservations;

public sealed record ReservationTotalAmount
{
    public decimal Value { get; }

    public ReservationTotalAmount(decimal value)
    {
        Value = ValueObjectGuards.NonNegative(value, nameof(ReservationTotalAmount));
    }
}
