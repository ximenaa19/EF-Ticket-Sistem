using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.DocumentTypes;

public sealed record DocumentTypeName
{
    public string Value { get; }

    public DocumentTypeName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(DocumentTypeName), 80, 1, false);
    }

    public override string ToString() => Value;
}
