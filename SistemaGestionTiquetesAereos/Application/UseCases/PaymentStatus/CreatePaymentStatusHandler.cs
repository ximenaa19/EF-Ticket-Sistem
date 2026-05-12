using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentStatus;

public sealed class CreatePaymentStatusHandler : IRequestHandler<CreatePaymentStatusCommand, Guid>
{
    private readonly IPaymentStatus _paymentStatusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePaymentStatusHandler(IPaymentStatus paymentStatusRepository, IUnitOfWork unitOfWork)
    {
        _paymentStatusRepository = paymentStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreatePaymentStatusCommand request, CancellationToken cancellationToken)
    {
        if (await _paymentStatusRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("PaymentStatus with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.PaymentStatus(request.Name);

        await _paymentStatusRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
