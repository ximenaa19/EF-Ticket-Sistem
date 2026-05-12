using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class PaymentMethod : BaseEntity
{
    private PaymentMethod()
    {

    }

    public PaymentMethod(Guid clientId, Guid paymentMethodTypeId, Guid? cardIssuerId, Guid? cardTypeId, string? maskedNumber)
    {
        Validate(clientId, paymentMethodTypeId, cardIssuerId, cardTypeId, maskedNumber);

        ClientId = clientId;
        PaymentMethodTypeId = paymentMethodTypeId;
        CardIssuerId = cardIssuerId;
        CardTypeId = cardTypeId;
        MaskedNumber = string.IsNullOrWhiteSpace(maskedNumber) ? null : maskedNumber.Trim();
        IsActive = true;
    }

    public Guid ClientId { get; private set; }
    public Guid PaymentMethodTypeId { get; private set; }
    public Guid? CardIssuerId { get; private set; }
    public Guid? CardTypeId { get; private set; }
    public string? MaskedNumber { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid clientId, Guid paymentMethodTypeId, Guid? cardIssuerId, Guid? cardTypeId, string? maskedNumber, bool isActive)
    {
        Validate(clientId, paymentMethodTypeId, cardIssuerId, cardTypeId, maskedNumber);

        ClientId = clientId;
        PaymentMethodTypeId = paymentMethodTypeId;
        CardIssuerId = cardIssuerId;
        CardTypeId = cardTypeId;
        MaskedNumber = string.IsNullOrWhiteSpace(maskedNumber) ? null : maskedNumber.Trim();
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

    private static void Validate(Guid clientId, Guid paymentMethodTypeId, Guid? cardIssuerId, Guid? cardTypeId, string? maskedNumber)
    {
        if (clientId == Guid.Empty)
        {
            throw new InvalidDomainStateException("ClientId is required.");
        }

        if (paymentMethodTypeId == Guid.Empty)
        {
            throw new InvalidDomainStateException("PaymentMethodTypeId is required.");
        }

        if (!string.IsNullOrWhiteSpace(maskedNumber) && maskedNumber.Trim().Length > 30)
        {
            throw new InvalidDomainStateException("MaskedNumber cannot exceed 30 characters.");
        }
    }
}
