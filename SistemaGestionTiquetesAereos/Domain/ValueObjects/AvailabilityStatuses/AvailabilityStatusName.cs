using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.AvailabilityStatuses;

public sealed record AvailabilityStatusName
{
    public string Value { get; }

    public AvailabilityStatusName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(AvailabilityStatusName), 80, 1, false);
    }

    public override string ToString() => Value;
}
