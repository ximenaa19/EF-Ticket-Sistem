using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class PhoneCode : BaseEntity
{
    private PhoneCode()
    {
        Code = string.Empty;
    }

    public PhoneCode(Guid countryId, string code)
    {
        Validate(countryId, code);

        CountryId = countryId;
        Code = code.Trim().ToUpperInvariant();
        IsActive = true;
    }

    public Guid CountryId { get; private set; }
    public string Code { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid countryId, string code, bool isActive)
    {
        Validate(countryId, code);

        CountryId = countryId;
        Code = code.Trim().ToUpperInvariant();
        IsActive = isActive;

        MarkAsUpdated();
    }

    public void Activate()
    {
        IsActive = true;
        MarkAsUpdated();
    }

    public void Deactivate()
    {
        IsActive = false;
        MarkAsUpdated();
    }

    private static void Validate(Guid countryId, string code)
    {
        if (countryId == Guid.Empty)
        {
            throw new InvalidDomainStateException("CountryId is required.");
        }

        if (string.IsNullOrWhiteSpace(code))
        {
            throw new InvalidDomainStateException("Code is required.");
        }
        if (code.Trim().Length > 10)
        {
            throw new InvalidDomainStateException("Code cannot exceed 10 characters.");
        }
    }
}
