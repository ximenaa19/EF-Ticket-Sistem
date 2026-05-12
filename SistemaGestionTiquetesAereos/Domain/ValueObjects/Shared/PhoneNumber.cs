using System.Text.RegularExpressions;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.ValueObjects.Shared;

public sealed record PhoneNumber
{
    private static readonly Regex Pattern = new(
        @"^\+?[0-9]{7,15}$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public string Value { get; }

    public PhoneNumber(string value)
    {
        var normalized = value?.Trim().Replace(" ", string.Empty) ?? string.Empty;

        if (!Pattern.IsMatch(normalized))
        {
            throw new InvalidDomainStateException("Phone number has an invalid format.");
        }

        Value = normalized;
    }

    public override string ToString() => Value;
}
