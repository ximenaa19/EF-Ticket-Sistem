using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItem;

public sealed class GetInvoiceItemsHandler : IRequestHandler<GetInvoiceItemsQuery, IReadOnlyList<Domain.Entities.InvoiceItem>>
{
    private readonly IInvoiceItem _invoiceItemRepository;

    public GetInvoiceItemsHandler(IInvoiceItem invoiceItemRepository)
    {
        _invoiceItemRepository = invoiceItemRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.InvoiceItem>> Handle(GetInvoiceItemsQuery request, CancellationToken cancellationToken)
    {
        return _invoiceItemRepository.GetAllAsync(cancellationToken);
    }
}
