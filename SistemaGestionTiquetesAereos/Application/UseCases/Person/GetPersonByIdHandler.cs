using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Person;

public sealed class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, Domain.Entities.Person>
{
    private readonly IPerson _personRepository;

    public GetPersonByIdHandler(IPerson personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Domain.Entities.Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        return await _personRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Person), request.Id);
    }
}
