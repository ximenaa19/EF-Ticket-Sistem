using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentStatus;

public sealed class GetPaymentStatusesHandler : IRequestHandler<GetPaymentStatusesQuery, IReadOnlyList<Domain.Entities.PaymentStatus>>
{
    private readonly IPaymentStatus _paymentStatusRepository;

    public GetPaymentStatusesHandler(IPaymentStatus paymentStatusRepository)
    {
        _paymentStatusRepository = paymentStatusRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.PaymentStatus>> Handle(GetPaymentStatusesQuery request, CancellationToken cancellationToken)
    {
        return _paymentStatusRepository.GetAllAsync(cancellationToken);
    }
}
