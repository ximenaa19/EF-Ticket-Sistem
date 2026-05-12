using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airline;

public sealed class GetAirlinesHandler : IRequestHandler<GetAirlinesQuery, IReadOnlyList<Domain.Entities.Airline>>
{
    private readonly IAirline _airlineRepository;

    public GetAirlinesHandler(IAirline airlineRepository)
    {
        _airlineRepository = airlineRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Airline>> Handle(GetAirlinesQuery request, CancellationToken cancellationToken)
    {
        return _airlineRepository.GetAllAsync(cancellationToken);
    }
}
