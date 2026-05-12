using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Flights;

public sealed record DepartureDate
{
    public DateTime Value { get; }

    public DepartureDate(DateTime value)
    {
        Value = ValueObjectGuards.RequiredDate(value, nameof(DepartureDate));
    }
}
