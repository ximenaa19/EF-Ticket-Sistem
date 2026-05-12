using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.People;

public sealed record BirthDate
{
    public DateTime Value { get; }

    public BirthDate(DateTime value)
    {
        Value = ValueObjectGuards.RequiredDate(value, nameof(BirthDate));
    }
}
