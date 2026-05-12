using System.Text.RegularExpressions;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.ValueObjects.Airports;

public sealed record IataCode
{
    private static readonly Regex Pattern = new(
        @"^[A-Z0-9]{2,3}$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public string Value { get; }

    public IataCode(string value)
    {
        var normalized = value?.Trim().ToUpperInvariant() ?? string.Empty;

        if (!Pattern.IsMatch(normalized))
        {
            throw new InvalidDomainStateException("IATA code must contain two or three uppercase letters or digits.");
        }

        Value = normalized;
    }

    public override string ToString() => Value;
}
