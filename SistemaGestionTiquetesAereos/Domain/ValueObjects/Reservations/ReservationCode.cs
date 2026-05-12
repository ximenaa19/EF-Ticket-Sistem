using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Reservations;

public sealed record ReservationCode
{
    public string Value { get; }

    public ReservationCode(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(ReservationCode), 30, 2, true);
    }

    public override string ToString() => Value;
}
