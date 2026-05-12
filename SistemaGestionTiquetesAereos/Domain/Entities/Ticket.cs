using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Ticket : BaseEntity
{
    private Ticket()
    {
        TicketNumber = string.Empty;
        Currency = string.Empty;
    }

    public Ticket(Guid reservationId, Guid passengerId, Guid flightId, Guid ticketStatusId, string ticketNumber, decimal fareAmount, string currency)
    {
        Validate(reservationId, passengerId, flightId, ticketStatusId, ticketNumber, fareAmount, currency);

        ReservationId = reservationId;
        PassengerId = passengerId;
        FlightId = flightId;
        TicketStatusId = ticketStatusId;
        TicketNumber = ticketNumber.Trim();
        FareAmount = fareAmount;
        Currency = currency.Trim().ToUpperInvariant();
        IsActive = true;
    }

    public Guid ReservationId { get; private set; }
    public Guid PassengerId { get; private set; }
    public Guid FlightId { get; private set; }
    public Guid TicketStatusId { get; private set; }
    public string TicketNumber { get; private set; }
    public decimal FareAmount { get; private set; }
    public string Currency { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid reservationId, Guid passengerId, Guid flightId, Guid ticketStatusId, string ticketNumber, decimal fareAmount, string currency, bool isActive)
    {
        Validate(reservationId, passengerId, flightId, ticketStatusId, ticketNumber, fareAmount, currency);

        ReservationId = reservationId;
        PassengerId = passengerId;
        FlightId = flightId;
        TicketStatusId = ticketStatusId;
        TicketNumber = ticketNumber.Trim();
        FareAmount = fareAmount;
        Currency = currency.Trim().ToUpperInvariant();
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

    private static void Validate(Guid reservationId, Guid passengerId, Guid flightId, Guid ticketStatusId, string ticketNumber, decimal fareAmount, string currency)
    {
        if (reservationId == Guid.Empty)
        {
            throw new InvalidDomainStateException("ReservationId is required.");
        }

        if (passengerId == Guid.Empty)
        {
            throw new InvalidDomainStateException("PassengerId is required.");
        }

        if (flightId == Guid.Empty)
        {
            throw new InvalidDomainStateException("FlightId is required.");
        }

        if (ticketStatusId == Guid.Empty)
        {
            throw new InvalidDomainStateException("TicketStatusId is required.");
        }

        if (string.IsNullOrWhiteSpace(ticketNumber))
        {
            throw new InvalidDomainStateException("TicketNumber is required.");
        }
        if (ticketNumber.Trim().Length > 40)
        {
            throw new InvalidDomainStateException("TicketNumber cannot exceed 40 characters.");
        }

        if (fareAmount < 0)
        {
            throw new InvalidDomainStateException("FareAmount cannot be negative.");
        }

        if (string.IsNullOrWhiteSpace(currency))
        {
            throw new InvalidDomainStateException("Currency is required.");
        }
        if (currency.Trim().Length > 3)
        {
            throw new InvalidDomainStateException("Currency cannot exceed 3 characters.");
        }
    }
}
