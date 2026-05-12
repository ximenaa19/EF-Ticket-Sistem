using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Address : BaseEntity
{
    private Address()
    {
        Street = string.Empty;
        Number = string.Empty;
    }

    public Address(Guid roadTypeId, Guid cityId, string street, string number, string? additionalInfo)
    {
        Validate(roadTypeId, cityId, street, number, additionalInfo);

        RoadTypeId = roadTypeId;
        CityId = cityId;
        Street = street.Trim();
        Number = number.Trim();
        AdditionalInfo = string.IsNullOrWhiteSpace(additionalInfo) ? null : additionalInfo.Trim();
        IsActive = true;
    }

    public Guid RoadTypeId { get; private set; }
    public Guid CityId { get; private set; }
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string? AdditionalInfo { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid roadTypeId, Guid cityId, string street, string number, string? additionalInfo, bool isActive)
    {
        Validate(roadTypeId, cityId, street, number, additionalInfo);

        RoadTypeId = roadTypeId;
        CityId = cityId;
        Street = street.Trim();
        Number = number.Trim();
        AdditionalInfo = string.IsNullOrWhiteSpace(additionalInfo) ? null : additionalInfo.Trim();
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

    private static void Validate(Guid roadTypeId, Guid cityId, string street, string number, string? additionalInfo)
    {
        if (roadTypeId == Guid.Empty)
        {
            throw new InvalidDomainStateException("RoadTypeId is required.");
        }

        if (cityId == Guid.Empty)
        {
            throw new InvalidDomainStateException("CityId is required.");
        }

        if (string.IsNullOrWhiteSpace(street))
        {
            throw new InvalidDomainStateException("Street is required.");
        }
        if (street.Trim().Length > 150)
        {
            throw new InvalidDomainStateException("Street cannot exceed 150 characters.");
        }

        if (string.IsNullOrWhiteSpace(number))
        {
            throw new InvalidDomainStateException("Number is required.");
        }
        if (number.Trim().Length > 30)
        {
            throw new InvalidDomainStateException("Number cannot exceed 30 characters.");
        }

        if (!string.IsNullOrWhiteSpace(additionalInfo) && additionalInfo.Trim().Length > 250)
        {
            throw new InvalidDomainStateException("AdditionalInfo cannot exceed 250 characters.");
        }
    }
}
