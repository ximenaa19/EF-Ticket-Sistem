using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Addresses;

public sealed record AddressNumber
{
    public string Value { get; }

    public AddressNumber(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(AddressNumber), 30, 1, false);
    }

    public override string ToString() => Value;
}
