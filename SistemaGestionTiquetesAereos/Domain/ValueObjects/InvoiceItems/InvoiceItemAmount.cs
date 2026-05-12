using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.InvoiceItems;

public sealed record InvoiceItemAmount
{
    public decimal Value { get; }

    public InvoiceItemAmount(decimal value)
    {
        Value = ValueObjectGuards.NonNegative(value, nameof(InvoiceItemAmount));
    }
}
