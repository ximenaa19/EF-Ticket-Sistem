using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.AircraftManufacturers;

public sealed record AircraftManufacturerName
{
    public string Value { get; }

    public AircraftManufacturerName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(AircraftManufacturerName), 120, 1, false);
    }

    public override string ToString() => Value;
}
