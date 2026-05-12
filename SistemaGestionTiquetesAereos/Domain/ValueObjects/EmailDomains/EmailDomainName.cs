using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.EmailDomains;

public sealed record EmailDomainName
{
    public string Value { get; }

    public EmailDomainName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(EmailDomainName), 120, 1, false);
    }

    public override string ToString() => Value;
}
