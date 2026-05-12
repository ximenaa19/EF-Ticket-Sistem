using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethodType;

public sealed class DeletePaymentMethodTypeHandler : IRequestHandler<DeletePaymentMethodTypeCommand>
{
    private readonly IPaymentMethodType _paymentMethodTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePaymentMethodTypeHandler(IPaymentMethodType paymentMethodTypeRepository, IUnitOfWork unitOfWork)
    {
        _paymentMethodTypeRepository = paymentMethodTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeletePaymentMethodTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _paymentMethodTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PaymentMethodType), request.Id);

        _paymentMethodTypeRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
