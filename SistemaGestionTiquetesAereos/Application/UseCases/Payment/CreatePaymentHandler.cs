using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Payment;

public sealed class CreatePaymentHandler : IRequestHandler<CreatePaymentCommand, Guid>
{
    private readonly IPayment _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePaymentHandler(IPayment paymentRepository, IUnitOfWork unitOfWork)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Payment(request.ReservationId, request.PaymentMethodId, request.PaymentStatusId, request.Amount, request.Currency, request.PaidAt);

        await _paymentRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
