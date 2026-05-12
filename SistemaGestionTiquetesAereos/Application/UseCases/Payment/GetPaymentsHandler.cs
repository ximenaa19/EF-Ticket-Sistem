using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Payment;

public sealed class GetPaymentsHandler : IRequestHandler<GetPaymentsQuery, IReadOnlyList<Domain.Entities.Payment>>
{
    private readonly IPayment _paymentRepository;

    public GetPaymentsHandler(IPayment paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Payment>> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
    {
        return _paymentRepository.GetAllAsync(cancellationToken);
    }
}
