using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Season;

public sealed class GetSeasonsHandler : IRequestHandler<GetSeasonsQuery, IReadOnlyList<Domain.Entities.Season>>
{
    private readonly ISeason _seasonRepository;

    public GetSeasonsHandler(ISeason seasonRepository)
    {
        _seasonRepository = seasonRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Season>> Handle(GetSeasonsQuery request, CancellationToken cancellationToken)
    {
        return _seasonRepository.GetAllAsync(cancellationToken);
    }
}
