using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.ValueObjects.Shared;

public static class ValueObjectGuards
{
    public static string RequiredText(
        string value,
        string fieldName,
        int maxLength,
        int minLength = 1,
        bool uppercase = false)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidDomainStateException($"{fieldName} is required.");
        }

        var normalized = value.Trim();

        if (normalized.Length < minLength)
        {
            throw new InvalidDomainStateException($"{fieldName} must contain at least {minLength} characters.");
        }

        if (normalized.Length > maxLength)
        {
            throw new InvalidDomainStateException($"{fieldName} cannot exceed {maxLength} characters.");
        }

        return uppercase ? normalized.ToUpperInvariant() : normalized;
    }

    public static string? OptionalText(string? value, string fieldName, int maxLength)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        var normalized = value.Trim();

        if (normalized.Length > maxLength)
        {
            throw new InvalidDomainStateException($"{fieldName} cannot exceed {maxLength} characters.");
        }

        return normalized;
    }

    public static int NonNegative(int value, string fieldName)
    {
        if (value < 0)
        {
            throw new InvalidDomainStateException($"{fieldName} cannot be negative.");
        }

        return value;
    }

    public static int Positive(int value, string fieldName)
    {
        if (value <= 0)
        {
            throw new InvalidDomainStateException($"{fieldName} must be greater than zero.");
        }

        return value;
    }

    public static decimal NonNegative(decimal value, string fieldName)
    {
        if (value < 0)
        {
            throw new InvalidDomainStateException($"{fieldName} cannot be negative.");
        }

        return value;
    }

    public static DateTime RequiredDate(DateTime value, string fieldName)
    {
        if (value == default)
        {
            throw new InvalidDomainStateException($"{fieldName} is required.");
        }

        return value;
    }

    public static void EnsureDateOrder(DateTime start, DateTime end, string fieldName)
    {
        if (end < start)
        {
            throw new InvalidDomainStateException($"{fieldName} end date cannot be earlier than start date.");
        }
    }
}
