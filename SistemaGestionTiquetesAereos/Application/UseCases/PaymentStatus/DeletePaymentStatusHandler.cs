using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentStatus;

public sealed class DeletePaymentStatusHandler : IRequestHandler<DeletePaymentStatusCommand>
{
    private readonly IPaymentStatus _paymentStatusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePaymentStatusHandler(IPaymentStatus paymentStatusRepository, IUnitOfWork unitOfWork)
    {
        _paymentStatusRepository = paymentStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeletePaymentStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _paymentStatusRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PaymentStatus), request.Id);

        _paymentStatusRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
