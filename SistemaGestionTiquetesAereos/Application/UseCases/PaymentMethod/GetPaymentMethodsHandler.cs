using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethod;

public sealed class GetPaymentMethodsHandler : IRequestHandler<GetPaymentMethodsQuery, IReadOnlyList<Domain.Entities.PaymentMethod>>
{
    private readonly IPaymentMethod _paymentMethodRepository;

    public GetPaymentMethodsHandler(IPaymentMethod paymentMethodRepository)
    {
        _paymentMethodRepository = paymentMethodRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.PaymentMethod>> Handle(GetPaymentMethodsQuery request, CancellationToken cancellationToken)
    {
        return _paymentMethodRepository.GetAllAsync(cancellationToken);
    }
}
