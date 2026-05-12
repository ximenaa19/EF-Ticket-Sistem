using System.Text.RegularExpressions;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.ValueObjects.Shared;

public sealed record Email
{
    private static readonly Regex Pattern = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !Pattern.IsMatch(value))
        {
            throw new InvalidDomainStateException("Email has an invalid format.");
        }

        Value = value.Trim().ToLowerInvariant();
    }

    public override string ToString() => Value;
}
