using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Invoice : BaseEntity
{
    private Invoice()
    {
        InvoiceNumber = string.Empty;
        Currency = string.Empty;
    }

    public Invoice(Guid reservationId, string invoiceNumber, DateTime issuedAt, decimal totalAmount, string currency)
    {
        Validate(reservationId, invoiceNumber, issuedAt, totalAmount, currency);

        ReservationId = reservationId;
        InvoiceNumber = invoiceNumber.Trim();
        IssuedAt = issuedAt;
        TotalAmount = totalAmount;
        Currency = currency.Trim().ToUpperInvariant();
        IsActive = true;
    }

    public Guid ReservationId { get; private set; }
    public string InvoiceNumber { get; private set; }
    public DateTime IssuedAt { get; private set; }
    public decimal TotalAmount { get; private set; }
    public string Currency { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid reservationId, string invoiceNumber, DateTime issuedAt, decimal totalAmount, string currency, bool isActive)
    {
        Validate(reservationId, invoiceNumber, issuedAt, totalAmount, currency);

        ReservationId = reservationId;
        InvoiceNumber = invoiceNumber.Trim();
        IssuedAt = issuedAt;
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

    private static void Validate(Guid reservationId, string invoiceNumber, DateTime issuedAt, decimal totalAmount, string currency)
    {
        if (reservationId == Guid.Empty)
        {
            throw new InvalidDomainStateException("ReservationId is required.");
        }

        if (string.IsNullOrWhiteSpace(invoiceNumber))
        {
            throw new InvalidDomainStateException("InvoiceNumber is required.");
        }
        if (invoiceNumber.Trim().Length > 40)
        {
            throw new InvalidDomainStateException("InvoiceNumber cannot exceed 40 characters.");
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
