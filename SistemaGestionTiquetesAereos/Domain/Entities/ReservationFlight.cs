using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class ReservationFlight : BaseEntity
{
    private ReservationFlight()
    {

    }

    public ReservationFlight(Guid reservationId, Guid flightId)
    {
        Validate(reservationId, flightId);

        ReservationId = reservationId;
        FlightId = flightId;
        IsActive = true;
    }

    public Guid ReservationId { get; private set; }
    public Guid FlightId { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid reservationId, Guid flightId, bool isActive)
    {
        Validate(reservationId, flightId);

        ReservationId = reservationId;
        FlightId = flightId;
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

    private static void Validate(Guid reservationId, Guid flightId)
    {
        if (reservationId == Guid.Empty)
        {
            throw new InvalidDomainStateException("ReservationId is required.");
        }

        if (flightId == Guid.Empty)
        {
            throw new InvalidDomainStateException("FlightId is required.");
        }
    }
}
