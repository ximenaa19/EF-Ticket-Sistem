using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class FlightSeat : BaseEntity
{
    private FlightSeat()
    {
        SeatNumber = string.Empty;
    }

    public FlightSeat(Guid flightId, string seatNumber, Guid cabinTypeId, Guid seatLocationTypeId, Guid availabilityStatusId)
    {
        Validate(flightId, seatNumber, cabinTypeId, seatLocationTypeId, availabilityStatusId);

        FlightId = flightId;
        SeatNumber = seatNumber.Trim();
        CabinTypeId = cabinTypeId;
        SeatLocationTypeId = seatLocationTypeId;
        AvailabilityStatusId = availabilityStatusId;
        IsActive = true;
    }

    public Guid FlightId { get; private set; }
    public string SeatNumber { get; private set; }
    public Guid CabinTypeId { get; private set; }
    public Guid SeatLocationTypeId { get; private set; }
    public Guid AvailabilityStatusId { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid flightId, string seatNumber, Guid cabinTypeId, Guid seatLocationTypeId, Guid availabilityStatusId, bool isActive)
    {
        Validate(flightId, seatNumber, cabinTypeId, seatLocationTypeId, availabilityStatusId);

        FlightId = flightId;
        SeatNumber = seatNumber.Trim();
        CabinTypeId = cabinTypeId;
        SeatLocationTypeId = seatLocationTypeId;
        AvailabilityStatusId = availabilityStatusId;
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

    private static void Validate(Guid flightId, string seatNumber, Guid cabinTypeId, Guid seatLocationTypeId, Guid availabilityStatusId)
    {
        if (flightId == Guid.Empty)
        {
            throw new InvalidDomainStateException("FlightId is required.");
        }

        if (string.IsNullOrWhiteSpace(seatNumber))
        {
            throw new InvalidDomainStateException("SeatNumber is required.");
        }
        if (seatNumber.Trim().Length > 10)
        {
            throw new InvalidDomainStateException("SeatNumber cannot exceed 10 characters.");
        }

        if (cabinTypeId == Guid.Empty)
        {
            throw new InvalidDomainStateException("CabinTypeId is required.");
        }

        if (seatLocationTypeId == Guid.Empty)
        {
            throw new InvalidDomainStateException("SeatLocationTypeId is required.");
        }

        if (availabilityStatusId == Guid.Empty)
        {
            throw new InvalidDomainStateException("AvailabilityStatusId is required.");
        }
    }
}
