using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.CheckIns;

public sealed record CheckInDate
{
    public DateTime Value { get; }

    public CheckInDate(DateTime value)
    {
        Value = ValueObjectGuards.RequiredDate(value, nameof(CheckInDate));
    }
}
