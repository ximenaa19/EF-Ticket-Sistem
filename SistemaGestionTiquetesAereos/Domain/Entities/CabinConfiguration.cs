using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class CabinConfiguration : BaseEntity
{
    private CabinConfiguration()
    {

    }

    public CabinConfiguration(Guid aircraftId, Guid cabinTypeId, int seatCount)
    {
        Validate(aircraftId, cabinTypeId, seatCount);

        AircraftId = aircraftId;
        CabinTypeId = cabinTypeId;
        SeatCount = seatCount;
        IsActive = true;
    }

    public Guid AircraftId { get; private set; }
    public Guid CabinTypeId { get; private set; }
    public int SeatCount { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid aircraftId, Guid cabinTypeId, int seatCount, bool isActive)
    {
        Validate(aircraftId, cabinTypeId, seatCount);

        AircraftId = aircraftId;
        CabinTypeId = cabinTypeId;
        SeatCount = seatCount;
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

    private static void Validate(Guid aircraftId, Guid cabinTypeId, int seatCount)
    {
        if (aircraftId == Guid.Empty)
        {
            throw new InvalidDomainStateException("AircraftId is required.");
        }

        if (cabinTypeId == Guid.Empty)
        {
            throw new InvalidDomainStateException("CabinTypeId is required.");
        }

        if (seatCount < 0)
        {
            throw new InvalidDomainStateException("SeatCount cannot be negative.");
        }
    }
}
