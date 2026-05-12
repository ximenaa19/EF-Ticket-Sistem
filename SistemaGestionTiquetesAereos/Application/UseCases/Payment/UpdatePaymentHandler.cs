using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Payment;

public sealed class UpdatePaymentHandler : IRequestHandler<UpdatePaymentCommand>
{
    private readonly IPayment _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePaymentHandler(IPayment paymentRepository, IUnitOfWork unitOfWork)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _paymentRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Payment), request.Id);

        entity.Update(request.ReservationId, request.PaymentMethodId, request.PaymentStatusId, request.Amount, request.Currency, request.PaidAt, request.IsActive);

        _paymentRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
