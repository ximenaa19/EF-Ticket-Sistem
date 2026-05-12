using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.City;

public sealed class GetCityByIdHandler : IRequestHandler<GetCityByIdQuery, Domain.Entities.City>
{
    private readonly ICity _cityRepository;

    public GetCityByIdHandler(ICity cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<Domain.Entities.City> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
    {
        return await _cityRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.City), request.Id);
    }
}
