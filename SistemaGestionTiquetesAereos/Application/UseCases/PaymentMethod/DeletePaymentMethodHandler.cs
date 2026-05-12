using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethod;

public sealed class DeletePaymentMethodHandler : IRequestHandler<DeletePaymentMethodCommand>
{
    private readonly IPaymentMethod _paymentMethodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePaymentMethodHandler(IPaymentMethod paymentMethodRepository, IUnitOfWork unitOfWork)
    {
        _paymentMethodRepository = paymentMethodRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeletePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        var entity = await _paymentMethodRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PaymentMethod), request.Id);

        _paymentMethodRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
