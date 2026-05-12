using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Airlines;

public sealed record AirlineName
{
    public string Value { get; }

    public AirlineName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(AirlineName), 150, 1, false);
    }

    public override string ToString() => Value;
}
