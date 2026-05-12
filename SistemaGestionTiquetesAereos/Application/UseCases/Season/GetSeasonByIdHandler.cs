using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Season;

public sealed class GetSeasonByIdHandler : IRequestHandler<GetSeasonByIdQuery, Domain.Entities.Season>
{
    private readonly ISeason _seasonRepository;

    public GetSeasonByIdHandler(ISeason seasonRepository)
    {
        _seasonRepository = seasonRepository;
    }

    public async Task<Domain.Entities.Season> Handle(GetSeasonByIdQuery request, CancellationToken cancellationToken)
    {
        return await _seasonRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Season), request.Id);
    }
}
