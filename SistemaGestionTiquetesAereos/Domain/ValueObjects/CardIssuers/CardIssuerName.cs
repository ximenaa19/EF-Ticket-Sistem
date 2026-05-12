using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.CardIssuers;

public sealed record CardIssuerName
{
    public string Value { get; }

    public CardIssuerName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(CardIssuerName), 80, 1, false);
    }

    public override string ToString() => Value;
}
