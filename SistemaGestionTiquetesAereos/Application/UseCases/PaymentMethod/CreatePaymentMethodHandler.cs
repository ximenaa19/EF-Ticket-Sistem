using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethod;

public sealed class CreatePaymentMethodHandler : IRequestHandler<CreatePaymentMethodCommand, Guid>
{
    private readonly IPaymentMethod _paymentMethodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePaymentMethodHandler(IPaymentMethod paymentMethodRepository, IUnitOfWork unitOfWork)
    {
        _paymentMethodRepository = paymentMethodRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreatePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.PaymentMethod(request.ClientId, request.PaymentMethodTypeId, request.CardIssuerId, request.CardTypeId, request.MaskedNumber);

        await _paymentMethodRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
