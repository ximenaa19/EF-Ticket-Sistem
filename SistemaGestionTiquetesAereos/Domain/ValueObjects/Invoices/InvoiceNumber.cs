using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Invoices;

public sealed record InvoiceNumber
{
    public string Value { get; }

    public InvoiceNumber(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(InvoiceNumber), 40, 2, true);
    }

    public override string ToString() => Value;
}
