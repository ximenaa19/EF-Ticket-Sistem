using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class ReservationPassenger : BaseEntity
{
    private ReservationPassenger()
    {

    }

    public ReservationPassenger(Guid reservationId, Guid passengerId)
    {
        Validate(reservationId, passengerId);

        ReservationId = reservationId;
        PassengerId = passengerId;
        IsActive = true;
    }

    public Guid ReservationId { get; private set; }
    public Guid PassengerId { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid reservationId, Guid passengerId, bool isActive)
    {
        Validate(reservationId, passengerId);

        ReservationId = reservationId;
        PassengerId = passengerId;
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

    private static void Validate(Guid reservationId, Guid passengerId)
    {
        if (reservationId == Guid.Empty)
        {
            throw new InvalidDomainStateException("ReservationId is required.");
        }

        if (passengerId == Guid.Empty)
        {
            throw new InvalidDomainStateException("PassengerId is required.");
        }
    }
}
