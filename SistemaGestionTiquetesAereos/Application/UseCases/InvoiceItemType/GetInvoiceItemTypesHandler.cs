using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItemType;

public sealed class GetInvoiceItemTypesHandler : IRequestHandler<GetInvoiceItemTypesQuery, IReadOnlyList<Domain.Entities.InvoiceItemType>>
{
    private readonly IInvoiceItemType _invoiceItemTypeRepository;

    public GetInvoiceItemTypesHandler(IInvoiceItemType invoiceItemTypeRepository)
    {
        _invoiceItemTypeRepository = invoiceItemTypeRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.InvoiceItemType>> Handle(GetInvoiceItemTypesQuery request, CancellationToken cancellationToken)
    {
        return _invoiceItemTypeRepository.GetAllAsync(cancellationToken);
    }
}
