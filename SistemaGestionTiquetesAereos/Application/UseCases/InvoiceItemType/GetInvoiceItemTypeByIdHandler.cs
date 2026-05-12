using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItemType;

public sealed class GetInvoiceItemTypeByIdHandler : IRequestHandler<GetInvoiceItemTypeByIdQuery, Domain.Entities.InvoiceItemType>
{
    private readonly IInvoiceItemType _invoiceItemTypeRepository;

    public GetInvoiceItemTypeByIdHandler(IInvoiceItemType invoiceItemTypeRepository)
    {
        _invoiceItemTypeRepository = invoiceItemTypeRepository;
    }

    public async Task<Domain.Entities.InvoiceItemType> Handle(GetInvoiceItemTypeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _invoiceItemTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.InvoiceItemType), request.Id);
    }
}
