using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PhoneCode;

public sealed class GetPhoneCodesHandler : IRequestHandler<GetPhoneCodesQuery, IReadOnlyList<Domain.Entities.PhoneCode>>
{
    private readonly IPhoneCode _phoneCodeRepository;

    public GetPhoneCodesHandler(IPhoneCode phoneCodeRepository)
    {
        _phoneCodeRepository = phoneCodeRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.PhoneCode>> Handle(GetPhoneCodesQuery request, CancellationToken cancellationToken)
    {
        return _phoneCodeRepository.GetAllAsync(cancellationToken);
    }
}
