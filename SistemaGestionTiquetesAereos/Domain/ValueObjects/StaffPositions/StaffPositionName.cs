using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.StaffPositions;

public sealed record StaffPositionName
{
    public string Value { get; }

    public StaffPositionName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(StaffPositionName), 100, 1, false);
    }

    public override string ToString() => Value;
}
