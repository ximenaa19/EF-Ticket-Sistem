using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Aircraft : BaseEntity
{
    private Aircraft()
    {
        RegistrationNumber = string.Empty;
    }

    public Aircraft(string registrationNumber, Guid airlineId, Guid aircraftModelId, Guid availabilityStatusId, int totalCapacity)
    {
        Validate(registrationNumber, airlineId, aircraftModelId, availabilityStatusId, totalCapacity);

        RegistrationNumber = registrationNumber.Trim();
        AirlineId = airlineId;
        AircraftModelId = aircraftModelId;
        AvailabilityStatusId = availabilityStatusId;
        TotalCapacity = totalCapacity;
        IsActive = true;
    }

    public string RegistrationNumber { get; private set; }
    public Guid AirlineId { get; private set; }
    public Guid AircraftModelId { get; private set; }
    public Guid AvailabilityStatusId { get; private set; }
    public int TotalCapacity { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(string registrationNumber, Guid airlineId, Guid aircraftModelId, Guid availabilityStatusId, int totalCapacity, bool isActive)
    {
        Validate(registrationNumber, airlineId, aircraftModelId, availabilityStatusId, totalCapacity);

        RegistrationNumber = registrationNumber.Trim();
        AirlineId = airlineId;
        AircraftModelId = aircraftModelId;
        AvailabilityStatusId = availabilityStatusId;
        TotalCapacity = totalCapacity;
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

    private static void Validate(string registrationNumber, Guid airlineId, Guid aircraftModelId, Guid availabilityStatusId, int totalCapacity)
    {
        if (string.IsNullOrWhiteSpace(registrationNumber))
        {
            throw new InvalidDomainStateException("RegistrationNumber is required.");
        }
        if (registrationNumber.Trim().Length > 30)
        {
            throw new InvalidDomainStateException("RegistrationNumber cannot exceed 30 characters.");
        }

        if (airlineId == Guid.Empty)
        {
            throw new InvalidDomainStateException("AirlineId is required.");
        }

        if (aircraftModelId == Guid.Empty)
        {
            throw new InvalidDomainStateException("AircraftModelId is required.");
        }

        if (availabilityStatusId == Guid.Empty)
        {
            throw new InvalidDomainStateException("AvailabilityStatusId is required.");
        }

        if (totalCapacity < 0)
        {
            throw new InvalidDomainStateException("TotalCapacity cannot be negative.");
        }
    }
}
