using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItemType;

public sealed class CreateInvoiceItemTypeHandler : IRequestHandler<CreateInvoiceItemTypeCommand, Guid>
{
    private readonly IInvoiceItemType _invoiceItemTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateInvoiceItemTypeHandler(IInvoiceItemType invoiceItemTypeRepository, IUnitOfWork unitOfWork)
    {
        _invoiceItemTypeRepository = invoiceItemTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateInvoiceItemTypeCommand request, CancellationToken cancellationToken)
    {
        if (await _invoiceItemTypeRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("InvoiceItemType with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.InvoiceItemType(request.Name);

        await _invoiceItemTypeRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
