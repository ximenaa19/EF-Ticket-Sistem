using System.Text.RegularExpressions;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.ValueObjects.People;

public sealed record DocumentNumber
{
    private static readonly Regex Pattern = new(
        @"^[A-Z0-9\-]{4,30}$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public string Value { get; }

    public DocumentNumber(string value)
    {
        var normalized = value?.Trim().ToUpperInvariant() ?? string.Empty;

        if (!Pattern.IsMatch(normalized))
        {
            throw new InvalidDomainStateException("Document number has an invalid format.");
        }

        Value = normalized;
    }

    public override string ToString() => Value;
}
