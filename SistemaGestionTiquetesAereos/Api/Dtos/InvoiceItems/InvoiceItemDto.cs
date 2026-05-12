namespace AirlineTicketSystem.Api.Dtos.InvoiceItems;

public sealed record InvoiceItemDto(
    Guid Id,
    Guid InvoiceId,
    Guid InvoiceItemTypeId,
    string Description,
    decimal Amount,
    string Currency,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
