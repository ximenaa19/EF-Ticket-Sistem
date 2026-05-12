using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Addresses;

public sealed record AddressAdditionalInfo
{
    public string? Value { get; }

    public AddressAdditionalInfo(string? value)
    {
        Value = ValueObjectGuards.OptionalText(value, nameof(AddressAdditionalInfo), 250);
    }

    public override string ToString() => Value ?? string.Empty;
}
