using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.CabinTypes;

public sealed record CabinTypeName
{
    public string Value { get; }

    public CabinTypeName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(CabinTypeName), 80, 1, false);
    }

    public override string ToString() => Value;
}
