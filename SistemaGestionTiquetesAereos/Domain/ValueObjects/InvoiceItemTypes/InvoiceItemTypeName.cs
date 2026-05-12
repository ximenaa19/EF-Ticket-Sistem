using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.InvoiceItemTypes;

public sealed record InvoiceItemTypeName
{
    public string Value { get; }

    public InvoiceItemTypeName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(InvoiceItemTypeName), 80, 1, false);
    }

    public override string ToString() => Value;
}
