using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckInStatus;

public sealed class GetCheckInStatusesHandler : IRequestHandler<GetCheckInStatusesQuery, IReadOnlyList<Domain.Entities.CheckInStatus>>
{
    private readonly ICheckInStatus _checkInStatusRepository;

    public GetCheckInStatusesHandler(ICheckInStatus checkInStatusRepository)
    {
        _checkInStatusRepository = checkInStatusRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.CheckInStatus>> Handle(GetCheckInStatusesQuery request, CancellationToken cancellationToken)
    {
        return _checkInStatusRepository.GetAllAsync(cancellationToken);
    }
}
