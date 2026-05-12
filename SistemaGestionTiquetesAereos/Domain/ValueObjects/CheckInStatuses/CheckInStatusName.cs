using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.CheckInStatuses;

public sealed record CheckInStatusName
{
    public string Value { get; }

    public CheckInStatusName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(CheckInStatusName), 80, 1, false);
    }

    public override string ToString() => Value;
}
