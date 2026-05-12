using System.Text.RegularExpressions;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.ValueObjects.Airports;

public sealed record IcaoCode
{
    private static readonly Regex Pattern = new(
        @"^[A-Z]{3,4}$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public string Value { get; }

    public IcaoCode(string value)
    {
        var normalized = value?.Trim().ToUpperInvariant() ?? string.Empty;

        if (!Pattern.IsMatch(normalized))
        {
            throw new InvalidDomainStateException("ICAO code must contain three or four uppercase letters.");
        }

        Value = normalized;
    }

    public override string ToString() => Value;
}
