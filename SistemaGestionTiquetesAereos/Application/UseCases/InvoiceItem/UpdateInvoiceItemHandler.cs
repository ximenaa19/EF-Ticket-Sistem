using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItem;

public sealed class UpdateInvoiceItemHandler : IRequestHandler<UpdateInvoiceItemCommand>
{
    private readonly IInvoiceItem _invoiceItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInvoiceItemHandler(IInvoiceItem invoiceItemRepository, IUnitOfWork unitOfWork)
    {
        _invoiceItemRepository = invoiceItemRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateInvoiceItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _invoiceItemRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.InvoiceItem), request.Id);

        entity.Update(request.InvoiceId, request.InvoiceItemTypeId, request.Description, request.Amount, request.Currency, request.IsActive);

        _invoiceItemRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
