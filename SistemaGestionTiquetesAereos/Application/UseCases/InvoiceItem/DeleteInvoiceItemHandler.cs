using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItem;

public sealed class DeleteInvoiceItemHandler : IRequestHandler<DeleteInvoiceItemCommand>
{
    private readonly IInvoiceItem _invoiceItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInvoiceItemHandler(IInvoiceItem invoiceItemRepository, IUnitOfWork unitOfWork)
    {
        _invoiceItemRepository = invoiceItemRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteInvoiceItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _invoiceItemRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.InvoiceItem), request.Id);

        _invoiceItemRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
