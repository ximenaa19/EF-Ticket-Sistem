using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckIn;

public sealed class GetCheckInsHandler : IRequestHandler<GetCheckInsQuery, IReadOnlyList<Domain.Entities.CheckIn>>
{
    private readonly ICheckIn _checkInRepository;

    public GetCheckInsHandler(ICheckIn checkInRepository)
    {
        _checkInRepository = checkInRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.CheckIn>> Handle(GetCheckInsQuery request, CancellationToken cancellationToken)
    {
        return _checkInRepository.GetAllAsync(cancellationToken);
    }
}
