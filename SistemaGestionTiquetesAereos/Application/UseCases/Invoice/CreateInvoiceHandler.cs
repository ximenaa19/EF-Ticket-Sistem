using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Invoice;

public sealed class CreateInvoiceHandler : IRequestHandler<CreateInvoiceCommand, Guid>
{
    private readonly IInvoice _invoiceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateInvoiceHandler(IInvoice invoiceRepository, IUnitOfWork unitOfWork)
    {
        _invoiceRepository = invoiceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        if (await _invoiceRepository.ExistsByInvoiceNumberAsync(request.InvoiceNumber, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("Invoice with InvoiceNumber '" + request.InvoiceNumber + "' already exists.");
        }
        var entity = new Domain.Entities.Invoice(request.ReservationId, request.InvoiceNumber, request.IssuedAt, request.TotalAmount, request.Currency);

        await _invoiceRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
