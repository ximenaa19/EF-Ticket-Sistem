using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Sessions;

public sealed record SessionExpirationDate
{
    public DateTime Value { get; }

    public SessionExpirationDate(DateTime value)
    {
        Value = ValueObjectGuards.RequiredDate(value, nameof(SessionExpirationDate));
    }
}
