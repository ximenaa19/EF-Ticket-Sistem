using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Payments;

public sealed record PaymentDate
{
    public DateTime Value { get; }

    public PaymentDate(DateTime value)
    {
        Value = ValueObjectGuards.RequiredDate(value, nameof(PaymentDate));
    }
}
