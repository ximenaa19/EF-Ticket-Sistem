using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class FlightAssignment : BaseEntity
{
    private FlightAssignment()
    {

    }

    public FlightAssignment(Guid flightId, Guid staffId, Guid flightRoleId)
    {
        Validate(flightId, staffId, flightRoleId);

        FlightId = flightId;
        StaffId = staffId;
        FlightRoleId = flightRoleId;
        IsActive = true;
    }

    public Guid FlightId { get; private set; }
    public Guid StaffId { get; private set; }
    public Guid FlightRoleId { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid flightId, Guid staffId, Guid flightRoleId, bool isActive)
    {
        Validate(flightId, staffId, flightRoleId);

        FlightId = flightId;
        StaffId = staffId;
        FlightRoleId = flightRoleId;
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

    private static void Validate(Guid flightId, Guid staffId, Guid flightRoleId)
    {
        if (flightId == Guid.Empty)
        {
            throw new InvalidDomainStateException("FlightId is required.");
        }

        if (staffId == Guid.Empty)
        {
            throw new InvalidDomainStateException("StaffId is required.");
        }

        if (flightRoleId == Guid.Empty)
        {
            throw new InvalidDomainStateException("FlightRoleId is required.");
        }
    }
}
