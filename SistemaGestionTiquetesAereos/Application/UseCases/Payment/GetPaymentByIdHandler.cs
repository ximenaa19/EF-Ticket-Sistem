using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Payment;

public sealed class GetPaymentByIdHandler : IRequestHandler<GetPaymentByIdQuery, Domain.Entities.Payment>
{
    private readonly IPayment _paymentRepository;

    public GetPaymentByIdHandler(IPayment paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<Domain.Entities.Payment> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
    {
        return await _paymentRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Payment), request.Id);
    }
}
