using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Continent;

public sealed class GetContinentByIdHandler : IRequestHandler<GetContinentByIdQuery, Domain.Entities.Continent>
{
    private readonly IContinent _continentRepository;

    public GetContinentByIdHandler(IContinent continentRepository)
    {
        _continentRepository = continentRepository;
    }

    public async Task<Domain.Entities.Continent> Handle(GetContinentByIdQuery request, CancellationToken cancellationToken)
    {
        return await _continentRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Continent), request.Id);
    }
}
