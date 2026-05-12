using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Invoice;

public sealed class GetInvoiceByIdHandler : IRequestHandler<GetInvoiceByIdQuery, Domain.Entities.Invoice>
{
    private readonly IInvoice _invoiceRepository;

    public GetInvoiceByIdHandler(IInvoice invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    public async Task<Domain.Entities.Invoice> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
    {
        return await _invoiceRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Invoice), request.Id);
    }
}
