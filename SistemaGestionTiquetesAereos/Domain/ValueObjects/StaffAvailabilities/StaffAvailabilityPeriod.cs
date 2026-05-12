using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.StaffAvailabilities;

public sealed record StaffAvailabilityPeriod
{
    public DateTime AvailableFrom { get; }
    public DateTime AvailableTo { get; }

    public StaffAvailabilityPeriod(DateTime availableFrom, DateTime availableTo)
    {
        AvailableFrom = ValueObjectGuards.RequiredDate(availableFrom, nameof(AvailableFrom));
        AvailableTo = ValueObjectGuards.RequiredDate(availableTo, nameof(AvailableTo));
        ValueObjectGuards.EnsureDateOrder(AvailableFrom, AvailableTo, nameof(StaffAvailabilityPeriod));
    }
}
