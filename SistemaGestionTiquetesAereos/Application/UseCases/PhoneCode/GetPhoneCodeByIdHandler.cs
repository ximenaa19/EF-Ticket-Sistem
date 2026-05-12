using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PhoneCode;

public sealed class GetPhoneCodeByIdHandler : IRequestHandler<GetPhoneCodeByIdQuery, Domain.Entities.PhoneCode>
{
    private readonly IPhoneCode _phoneCodeRepository;

    public GetPhoneCodeByIdHandler(IPhoneCode phoneCodeRepository)
    {
        _phoneCodeRepository = phoneCodeRepository;
    }

    public async Task<Domain.Entities.PhoneCode> Handle(GetPhoneCodeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _phoneCodeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PhoneCode), request.Id);
    }
}
