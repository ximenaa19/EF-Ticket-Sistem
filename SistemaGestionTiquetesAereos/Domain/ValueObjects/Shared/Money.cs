using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.ValueObjects.Shared;

public sealed record Money
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        if (amount < 0)
        {
            throw new InvalidDomainStateException("Money amount cannot be negative.");
        }

        if (string.IsNullOrWhiteSpace(currency) || currency.Trim().Length != 3)
        {
            throw new InvalidDomainStateException("Currency must be a three-letter ISO code.");
        }

        Amount = amount;
        Currency = currency.Trim().ToUpperInvariant();
    }
}
