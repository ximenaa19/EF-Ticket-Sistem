using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItemType;

public sealed class DeleteInvoiceItemTypeHandler : IRequestHandler<DeleteInvoiceItemTypeCommand>
{
    private readonly IInvoiceItemType _invoiceItemTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInvoiceItemTypeHandler(IInvoiceItemType invoiceItemTypeRepository, IUnitOfWork unitOfWork)
    {
        _invoiceItemTypeRepository = invoiceItemTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteInvoiceItemTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _invoiceItemTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.InvoiceItemType), request.Id);

        _invoiceItemTypeRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
