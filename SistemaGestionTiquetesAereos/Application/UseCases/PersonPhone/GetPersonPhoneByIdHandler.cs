using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonPhone;

public sealed class GetPersonPhoneByIdHandler : IRequestHandler<GetPersonPhoneByIdQuery, Domain.Entities.PersonPhone>
{
    private readonly IPersonPhone _personPhoneRepository;

    public GetPersonPhoneByIdHandler(IPersonPhone personPhoneRepository)
    {
        _personPhoneRepository = personPhoneRepository;
    }

    public async Task<Domain.Entities.PersonPhone> Handle(GetPersonPhoneByIdQuery request, CancellationToken cancellationToken)
    {
        return await _personPhoneRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PersonPhone), request.Id);
    }
}
