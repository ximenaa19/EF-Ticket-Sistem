using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Person;

public sealed class GetPeopleHandler : IRequestHandler<GetPeopleQuery, IReadOnlyList<Domain.Entities.Person>>
{
    private readonly IPerson _personRepository;

    public GetPeopleHandler(IPerson personRepository)
    {
        _personRepository = personRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Person>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
    {
        return _personRepository.GetAllAsync(cancellationToken);
    }
}
