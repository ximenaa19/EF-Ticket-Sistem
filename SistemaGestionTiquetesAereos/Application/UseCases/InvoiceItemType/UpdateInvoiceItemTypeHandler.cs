using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItemType;

public sealed class UpdateInvoiceItemTypeHandler : IRequestHandler<UpdateInvoiceItemTypeCommand>
{
    private readonly IInvoiceItemType _invoiceItemTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInvoiceItemTypeHandler(IInvoiceItemType invoiceItemTypeRepository, IUnitOfWork unitOfWork)
    {
        _invoiceItemTypeRepository = invoiceItemTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateInvoiceItemTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _invoiceItemTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.InvoiceItemType), request.Id);

        if (await _invoiceItemTypeRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("InvoiceItemType with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _invoiceItemTypeRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
