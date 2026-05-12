using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.InvoiceItems;

public sealed record InvoiceItemDescription
{
    public string Value { get; }

    public InvoiceItemDescription(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(InvoiceItemDescription), 250, 1, false);
    }

    public override string ToString() => Value;
}
