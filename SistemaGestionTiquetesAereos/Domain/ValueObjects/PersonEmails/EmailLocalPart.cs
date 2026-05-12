using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.PersonEmails;

public sealed record EmailLocalPart
{
    public string Value { get; }

    public EmailLocalPart(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(EmailLocalPart), 100, 1, false);
    }

    public override string ToString() => Value;
}
