using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Reservation : BaseEntity
{
    private Reservation()
    {
        ReservationCode = string.Empty;
        Currency = string.Empty;
    }

    public Reservation(Guid clientId, Guid reservationStatusId, string reservationCode, DateTime reservedAt, decimal totalAmount, string currency)
    {
        Validate(clientId, reservationStatusId, reservationCode, reservedAt, totalAmount, currency);

        ClientId = clientId;
        ReservationStatusId = reservationStatusId;
        ReservationCode = reservationCode.Trim().ToUpperInvariant();
        ReservedAt = reservedAt;
        TotalAmount = totalAmount;
        Currency = currency.Trim().ToUpperInvariant();
        IsActive = true;
    }

    public Guid ClientId { get; private set; }
    public Guid ReservationStatusId { get; private set; }
    public string ReservationCode { get; private set; }
    public DateTime ReservedAt { get; private set; }
    public decimal TotalAmount { get; private set; }
    public string Currency { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid clientId, Guid reservationStatusId, string reservationCode, DateTime reservedAt, decimal totalAmount, string currency, bool isActive)
    {
        Validate(clientId, reservationStatusId, reservationCode, reservedAt, totalAmount, currency);

        ClientId = clientId;
        ReservationStatusId = reservationStatusId;
        ReservationCode = reservationCode.Trim().ToUpperInvariant();
        ReservedAt = reservedAt;
        TotalAmount = totalAmount;
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

    private static void Validate(Guid clientId, Guid reservationStatusId, string reservationCode, DateTime reservedAt, decimal totalAmount, string currency)
    {
        if (clientId == Guid.Empty)
        {
            throw new InvalidDomainStateException("ClientId is required.");
        }

        if (reservationStatusId == Guid.Empty)
        {
            throw new InvalidDomainStateException("ReservationStatusId is required.");
        }

        if (string.IsNullOrWhiteSpace(reservationCode))
        {
            throw new InvalidDomainStateException("ReservationCode is required.");
        }
        if (reservationCode.Trim().Length > 30)
        {
            throw new InvalidDomainStateException("ReservationCode cannot exceed 30 characters.");
        }

        if (totalAmount < 0)
        {
            throw new InvalidDomainStateException("TotalAmount cannot be negative.");
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
