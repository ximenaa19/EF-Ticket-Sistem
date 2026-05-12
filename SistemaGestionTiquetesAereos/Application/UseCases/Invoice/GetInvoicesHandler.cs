using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Invoice;

public sealed class GetInvoicesHandler : IRequestHandler<GetInvoicesQuery, IReadOnlyList<Domain.Entities.Invoice>>
{
    private readonly IInvoice _invoiceRepository;

    public GetInvoicesHandler(IInvoice invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Invoice>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
    {
        return _invoiceRepository.GetAllAsync(cancellationToken);
    }
}
