using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethodType;

public sealed class GetPaymentMethodTypeByIdHandler : IRequestHandler<GetPaymentMethodTypeByIdQuery, Domain.Entities.PaymentMethodType>
{
    private readonly IPaymentMethodType _paymentMethodTypeRepository;

    public GetPaymentMethodTypeByIdHandler(IPaymentMethodType paymentMethodTypeRepository)
    {
        _paymentMethodTypeRepository = paymentMethodTypeRepository;
    }

    public async Task<Domain.Entities.PaymentMethodType> Handle(GetPaymentMethodTypeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _paymentMethodTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PaymentMethodType), request.Id);
    }
}
