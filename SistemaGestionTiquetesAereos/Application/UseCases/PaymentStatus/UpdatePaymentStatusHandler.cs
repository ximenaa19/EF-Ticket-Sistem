using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentStatus;

public sealed class UpdatePaymentStatusHandler : IRequestHandler<UpdatePaymentStatusCommand>
{
    private readonly IPaymentStatus _paymentStatusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePaymentStatusHandler(IPaymentStatus paymentStatusRepository, IUnitOfWork unitOfWork)
    {
        _paymentStatusRepository = paymentStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePaymentStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _paymentStatusRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PaymentStatus), request.Id);

        if (await _paymentStatusRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("PaymentStatus with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _paymentStatusRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
