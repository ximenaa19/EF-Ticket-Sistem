using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonPhone;

public sealed class GetPersonPhonesHandler : IRequestHandler<GetPersonPhonesQuery, IReadOnlyList<Domain.Entities.PersonPhone>>
{
    private readonly IPersonPhone _personPhoneRepository;

    public GetPersonPhonesHandler(IPersonPhone personPhoneRepository)
    {
        _personPhoneRepository = personPhoneRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.PersonPhone>> Handle(GetPersonPhonesQuery request, CancellationToken cancellationToken)
    {
        return _personPhoneRepository.GetAllAsync(cancellationToken);
    }
}
