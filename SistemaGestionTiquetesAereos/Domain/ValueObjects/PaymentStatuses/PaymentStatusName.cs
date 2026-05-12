using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.PaymentStatuses;

public sealed record PaymentStatusName
{
    public string Value { get; }

    public PaymentStatusName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(PaymentStatusName), 80, 1, false);
    }

    public override string ToString() => Value;
}
