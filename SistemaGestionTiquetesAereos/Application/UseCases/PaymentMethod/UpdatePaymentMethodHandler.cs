using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethod;

public sealed class UpdatePaymentMethodHandler : IRequestHandler<UpdatePaymentMethodCommand>
{
    private readonly IPaymentMethod _paymentMethodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePaymentMethodHandler(IPaymentMethod paymentMethodRepository, IUnitOfWork unitOfWork)
    {
        _paymentMethodRepository = paymentMethodRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        var entity = await _paymentMethodRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PaymentMethod), request.Id);

        entity.Update(request.ClientId, request.PaymentMethodTypeId, request.CardIssuerId, request.CardTypeId, request.MaskedNumber, request.IsActive);

        _paymentMethodRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
