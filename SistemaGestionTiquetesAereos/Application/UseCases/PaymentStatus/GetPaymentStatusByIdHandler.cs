using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentStatus;

public sealed class GetPaymentStatusByIdHandler : IRequestHandler<GetPaymentStatusByIdQuery, Domain.Entities.PaymentStatus>
{
    private readonly IPaymentStatus _paymentStatusRepository;

    public GetPaymentStatusByIdHandler(IPaymentStatus paymentStatusRepository)
    {
        _paymentStatusRepository = paymentStatusRepository;
    }

    public async Task<Domain.Entities.PaymentStatus> Handle(GetPaymentStatusByIdQuery request, CancellationToken cancellationToken)
    {
        return await _paymentStatusRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PaymentStatus), request.Id);
    }
}
