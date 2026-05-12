namespace AirlineTicketSystem.Api.Dtos.InvoiceItemTypes;

public sealed record InvoiceItemTypeDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
