using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Reservations;

public sealed record ReservationDate
{
    public DateTime Value { get; }

    public ReservationDate(DateTime value)
    {
        Value = ValueObjectGuards.RequiredDate(value, nameof(ReservationDate));
    }
}
