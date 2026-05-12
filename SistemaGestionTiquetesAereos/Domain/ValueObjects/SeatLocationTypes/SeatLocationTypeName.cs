using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.SeatLocationTypes;

public sealed record SeatLocationTypeName
{
    public string Value { get; }

    public SeatLocationTypeName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(SeatLocationTypeName), 80, 1, false);
    }

    public override string ToString() => Value;
}
