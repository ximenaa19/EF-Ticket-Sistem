using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethod;

public sealed class GetPaymentMethodByIdHandler : IRequestHandler<GetPaymentMethodByIdQuery, Domain.Entities.PaymentMethod>
{
    private readonly IPaymentMethod _paymentMethodRepository;

    public GetPaymentMethodByIdHandler(IPaymentMethod paymentMethodRepository)
    {
        _paymentMethodRepository = paymentMethodRepository;
    }

    public async Task<Domain.Entities.PaymentMethod> Handle(GetPaymentMethodByIdQuery request, CancellationToken cancellationToken)
    {
        return await _paymentMethodRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PaymentMethod), request.Id);
    }
}
