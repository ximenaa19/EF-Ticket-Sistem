using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethodType;

public sealed class GetPaymentMethodTypesHandler : IRequestHandler<GetPaymentMethodTypesQuery, IReadOnlyList<Domain.Entities.PaymentMethodType>>
{
    private readonly IPaymentMethodType _paymentMethodTypeRepository;

    public GetPaymentMethodTypesHandler(IPaymentMethodType paymentMethodTypeRepository)
    {
        _paymentMethodTypeRepository = paymentMethodTypeRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.PaymentMethodType>> Handle(GetPaymentMethodTypesQuery request, CancellationToken cancellationToken)
    {
        return _paymentMethodTypeRepository.GetAllAsync(cancellationToken);
    }
}
