using System.Text.RegularExpressions;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.ValueObjects.Flights;

public sealed record FlightCode
{
    private static readonly Regex Pattern = new(
        @"^[A-Z0-9]{2,3}[0-9]{1,4}$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public string Value { get; }

    public FlightCode(string value)
    {
        var normalized = value?.Trim().ToUpperInvariant() ?? string.Empty;

        if (!Pattern.IsMatch(normalized))
        {
            throw new InvalidDomainStateException("Flight code has an invalid format.");
        }

        Value = normalized;
    }

    public override string ToString() => Value;
}
