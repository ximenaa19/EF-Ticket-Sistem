using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.FlightSeats;

public sealed record SeatNumber
{
    public string Value { get; }

    public SeatNumber(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(SeatNumber), 10, 1, true);
    }

    public override string ToString() => Value;
}
