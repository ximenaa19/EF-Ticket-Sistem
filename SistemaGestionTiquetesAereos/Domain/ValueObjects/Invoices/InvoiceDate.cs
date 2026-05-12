using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Invoices;

public sealed record InvoiceDate
{
    public DateTime Value { get; }

    public InvoiceDate(DateTime value)
    {
        Value = ValueObjectGuards.RequiredDate(value, nameof(InvoiceDate));
    }
}
