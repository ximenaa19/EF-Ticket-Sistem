using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.ReservationStatuses;

public sealed record ReservationStatusName
{
    public string Value { get; }

    public ReservationStatusName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(ReservationStatusName), 80, 1, false);
    }

    public override string ToString() => Value;
}
