using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItem;

public sealed class CreateInvoiceItemHandler : IRequestHandler<CreateInvoiceItemCommand, Guid>
{
    private readonly IInvoiceItem _invoiceItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateInvoiceItemHandler(IInvoiceItem invoiceItemRepository, IUnitOfWork unitOfWork)
    {
        _invoiceItemRepository = invoiceItemRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateInvoiceItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.InvoiceItem(request.InvoiceId, request.InvoiceItemTypeId, request.Description, request.Amount, request.Currency);

        await _invoiceItemRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
