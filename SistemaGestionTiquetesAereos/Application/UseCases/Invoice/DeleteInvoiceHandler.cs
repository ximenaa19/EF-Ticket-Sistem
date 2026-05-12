using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Invoice;

public sealed class DeleteInvoiceHandler : IRequestHandler<DeleteInvoiceCommand>
{
    private readonly IInvoice _invoiceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInvoiceHandler(IInvoice invoiceRepository, IUnitOfWork unitOfWork)
    {
        _invoiceRepository = invoiceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _invoiceRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Invoice), request.Id);

        _invoiceRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
