using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethodType;

public sealed class UpdatePaymentMethodTypeHandler : IRequestHandler<UpdatePaymentMethodTypeCommand>
{
    private readonly IPaymentMethodType _paymentMethodTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePaymentMethodTypeHandler(IPaymentMethodType paymentMethodTypeRepository, IUnitOfWork unitOfWork)
    {
        _paymentMethodTypeRepository = paymentMethodTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePaymentMethodTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _paymentMethodTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PaymentMethodType), request.Id);

        if (await _paymentMethodTypeRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("PaymentMethodType with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _paymentMethodTypeRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
