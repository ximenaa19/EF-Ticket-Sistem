using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Payment;

public sealed class DeletePaymentHandler : IRequestHandler<DeletePaymentCommand>
{
    private readonly IPayment _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePaymentHandler(IPayment paymentRepository, IUnitOfWork unitOfWork)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _paymentRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Payment), request.Id);

        _paymentRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
