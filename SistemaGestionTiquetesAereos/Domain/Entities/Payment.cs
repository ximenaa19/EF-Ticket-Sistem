using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Payment : BaseEntity
{
    private Payment()
    {
        Currency = string.Empty;
    }

    public Payment(Guid reservationId, Guid paymentMethodId, Guid paymentStatusId, decimal amount, string currency, DateTime? paidAt)
    {
        Validate(reservationId, paymentMethodId, paymentStatusId, amount, currency, paidAt);

        ReservationId = reservationId;
        PaymentMethodId = paymentMethodId;
        PaymentStatusId = paymentStatusId;
        Amount = amount;
        Currency = currency.Trim().ToUpperInvariant();
        PaidAt = paidAt;
        IsActive = true;
    }

    public Guid ReservationId { get; private set; }
    public Guid PaymentMethodId { get; private set; }
    public Guid PaymentStatusId { get; private set; }
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }
    public DateTime? PaidAt { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid reservationId, Guid paymentMethodId, Guid paymentStatusId, decimal amount, string currency, DateTime? paidAt, bool isActive)
    {
        Validate(reservationId, paymentMethodId, paymentStatusId, amount, currency, paidAt);

        ReservationId = reservationId;
        PaymentMethodId = paymentMethodId;
        PaymentStatusId = paymentStatusId;
        Amount = amount;
        Currency = currency.Trim().ToUpperInvariant();
        PaidAt = paidAt;
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

    private static void Validate(Guid reservationId, Guid paymentMethodId, Guid paymentStatusId, decimal amount, string currency, DateTime? paidAt)
    {
        if (reservationId == Guid.Empty)
        {
            throw new InvalidDomainStateException("ReservationId is required.");
        }

        if (paymentMethodId == Guid.Empty)
        {
            throw new InvalidDomainStateException("PaymentMethodId is required.");
        }

        if (paymentStatusId == Guid.Empty)
        {
            throw new InvalidDomainStateException("PaymentStatusId is required.");
        }

        if (amount < 0)
        {
            throw new InvalidDomainStateException("Amount cannot be negative.");
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
