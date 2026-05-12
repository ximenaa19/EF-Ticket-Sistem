using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethodType;

public sealed class CreatePaymentMethodTypeHandler : IRequestHandler<CreatePaymentMethodTypeCommand, Guid>
{
    private readonly IPaymentMethodType _paymentMethodTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePaymentMethodTypeHandler(IPaymentMethodType paymentMethodTypeRepository, IUnitOfWork unitOfWork)
    {
        _paymentMethodTypeRepository = paymentMethodTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreatePaymentMethodTypeCommand request, CancellationToken cancellationToken)
    {
        if (await _paymentMethodTypeRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("PaymentMethodType with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.PaymentMethodType(request.Name);

        await _paymentMethodTypeRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
