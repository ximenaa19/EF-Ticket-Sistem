using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItem;

public sealed class GetInvoiceItemByIdHandler : IRequestHandler<GetInvoiceItemByIdQuery, Domain.Entities.InvoiceItem>
{
    private readonly IInvoiceItem _invoiceItemRepository;

    public GetInvoiceItemByIdHandler(IInvoiceItem invoiceItemRepository)
    {
        _invoiceItemRepository = invoiceItemRepository;
    }

    public async Task<Domain.Entities.InvoiceItem> Handle(GetInvoiceItemByIdQuery request, CancellationToken cancellationToken)
    {
        return await _invoiceItemRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.InvoiceItem), request.Id);
    }
}
