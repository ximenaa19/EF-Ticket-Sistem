using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class StaffAvailability : BaseEntity
{
    private StaffAvailability()
    {

    }

    public StaffAvailability(Guid staffId, Guid availabilityStatusId, DateTime availableFrom, DateTime availableTo)
    {
        Validate(staffId, availabilityStatusId, availableFrom, availableTo);

        StaffId = staffId;
        AvailabilityStatusId = availabilityStatusId;
        AvailableFrom = availableFrom;
        AvailableTo = availableTo;
        IsActive = true;
    }

    public Guid StaffId { get; private set; }
    public Guid AvailabilityStatusId { get; private set; }
    public DateTime AvailableFrom { get; private set; }
    public DateTime AvailableTo { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid staffId, Guid availabilityStatusId, DateTime availableFrom, DateTime availableTo, bool isActive)
    {
        Validate(staffId, availabilityStatusId, availableFrom, availableTo);

        StaffId = staffId;
        AvailabilityStatusId = availabilityStatusId;
        AvailableFrom = availableFrom;
        AvailableTo = availableTo;
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

    private static void Validate(Guid staffId, Guid availabilityStatusId, DateTime availableFrom, DateTime availableTo)
    {
        if (staffId == Guid.Empty)
        {
            throw new InvalidDomainStateException("StaffId is required.");
        }

        if (availabilityStatusId == Guid.Empty)
        {
            throw new InvalidDomainStateException("AvailabilityStatusId is required.");
        }
    }
}
