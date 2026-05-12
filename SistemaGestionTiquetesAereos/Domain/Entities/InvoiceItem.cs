using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class InvoiceItem : BaseEntity
{
    private InvoiceItem()
    {
        Description = string.Empty;
        Currency = string.Empty;
    }

    public InvoiceItem(Guid invoiceId, Guid invoiceItemTypeId, string description, decimal amount, string currency)
    {
        Validate(invoiceId, invoiceItemTypeId, description, amount, currency);

        InvoiceId = invoiceId;
        InvoiceItemTypeId = invoiceItemTypeId;
        Description = description.Trim();
        Amount = amount;
        Currency = currency.Trim().ToUpperInvariant();
        IsActive = true;
    }

    public Guid InvoiceId { get; private set; }
    public Guid InvoiceItemTypeId { get; private set; }
    public string Description { get; private set; }
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid invoiceId, Guid invoiceItemTypeId, string description, decimal amount, string currency, bool isActive)
    {
        Validate(invoiceId, invoiceItemTypeId, description, amount, currency);

        InvoiceId = invoiceId;
        InvoiceItemTypeId = invoiceItemTypeId;
        Description = description.Trim();
        Amount = amount;
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

    private static void Validate(Guid invoiceId, Guid invoiceItemTypeId, string description, decimal amount, string currency)
    {
        if (invoiceId == Guid.Empty)
        {
            throw new InvalidDomainStateException("InvoiceId is required.");
        }

        if (invoiceItemTypeId == Guid.Empty)
        {
            throw new InvalidDomainStateException("InvoiceItemTypeId is required.");
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new InvalidDomainStateException("Description is required.");
        }
        if (description.Trim().Length > 250)
        {
            throw new InvalidDomainStateException("Description cannot exceed 250 characters.");
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
