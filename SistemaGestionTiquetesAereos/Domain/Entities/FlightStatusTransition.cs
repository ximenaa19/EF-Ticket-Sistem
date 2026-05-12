using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class FlightStatusTransition : BaseEntity
{
    private FlightStatusTransition()
    {

    }

    public FlightStatusTransition(Guid flightId, Guid fromFlightStatusId, Guid toFlightStatusId, DateTime changedAt)
    {
        Validate(flightId, fromFlightStatusId, toFlightStatusId, changedAt);

        FlightId = flightId;
        FromFlightStatusId = fromFlightStatusId;
        ToFlightStatusId = toFlightStatusId;
        ChangedAt = changedAt;
        IsActive = true;
    }

    public Guid FlightId { get; private set; }
    public Guid FromFlightStatusId { get; private set; }
    public Guid ToFlightStatusId { get; private set; }
    public DateTime ChangedAt { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid flightId, Guid fromFlightStatusId, Guid toFlightStatusId, DateTime changedAt, bool isActive)
    {
        Validate(flightId, fromFlightStatusId, toFlightStatusId, changedAt);

        FlightId = flightId;
        FromFlightStatusId = fromFlightStatusId;
        ToFlightStatusId = toFlightStatusId;
        ChangedAt = changedAt;
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

    private static void Validate(Guid flightId, Guid fromFlightStatusId, Guid toFlightStatusId, DateTime changedAt)
    {
        if (flightId == Guid.Empty)
        {
            throw new InvalidDomainStateException("FlightId is required.");
        }

        if (fromFlightStatusId == Guid.Empty)
        {
            throw new InvalidDomainStateException("FromFlightStatusId is required.");
        }

        if (toFlightStatusId == Guid.Empty)
        {
            throw new InvalidDomainStateException("ToFlightStatusId is required.");
        }
    }
}
