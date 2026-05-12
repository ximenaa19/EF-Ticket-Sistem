using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Invoice;

public sealed class UpdateInvoiceHandler : IRequestHandler<UpdateInvoiceCommand>
{
    private readonly IInvoice _invoiceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInvoiceHandler(IInvoice invoiceRepository, IUnitOfWork unitOfWork)
    {
        _invoiceRepository = invoiceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _invoiceRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Invoice), request.Id);

        if (await _invoiceRepository.ExistsByInvoiceNumberAsync(request.InvoiceNumber, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("Invoice with InvoiceNumber '" + request.InvoiceNumber + "' already exists.");
        }
        entity.Update(request.ReservationId, request.InvoiceNumber, request.IssuedAt, request.TotalAmount, request.Currency, request.IsActive);

        _invoiceRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
