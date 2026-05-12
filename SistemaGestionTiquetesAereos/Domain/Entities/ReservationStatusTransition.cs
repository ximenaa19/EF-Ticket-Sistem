using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class ReservationStatusTransition : BaseEntity
{
    private ReservationStatusTransition()
    {

    }

    public ReservationStatusTransition(Guid reservationId, Guid fromReservationStatusId, Guid toReservationStatusId, DateTime changedAt)
    {
        Validate(reservationId, fromReservationStatusId, toReservationStatusId, changedAt);

        ReservationId = reservationId;
        FromReservationStatusId = fromReservationStatusId;
        ToReservationStatusId = toReservationStatusId;
        ChangedAt = changedAt;
        IsActive = true;
    }

    public Guid ReservationId { get; private set; }
    public Guid FromReservationStatusId { get; private set; }
    public Guid ToReservationStatusId { get; private set; }
    public DateTime ChangedAt { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid reservationId, Guid fromReservationStatusId, Guid toReservationStatusId, DateTime changedAt, bool isActive)
    {
        Validate(reservationId, fromReservationStatusId, toReservationStatusId, changedAt);

        ReservationId = reservationId;
        FromReservationStatusId = fromReservationStatusId;
        ToReservationStatusId = toReservationStatusId;
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

    private static void Validate(Guid reservationId, Guid fromReservationStatusId, Guid toReservationStatusId, DateTime changedAt)
    {
        if (reservationId == Guid.Empty)
        {
            throw new InvalidDomainStateException("ReservationId is required.");
        }

        if (fromReservationStatusId == Guid.Empty)
        {
            throw new InvalidDomainStateException("FromReservationStatusId is required.");
        }

        if (toReservationStatusId == Guid.Empty)
        {
            throw new InvalidDomainStateException("ToReservationStatusId is required.");
        }
    }
}
