using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItemType;

public sealed record UpdateInvoiceItemTypeCommand(Guid Id, string Name, bool IsActive) : IRequest;
