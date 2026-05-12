using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Flights;

public sealed record EstimatedArrivalDate
{
    public DateTime Value { get; }

    public EstimatedArrivalDate(DateTime value)
    {
        Value = ValueObjectGuards.RequiredDate(value, nameof(EstimatedArrivalDate));
    }
}
