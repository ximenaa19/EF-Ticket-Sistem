using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AvailabilityStatus;

public sealed class GetAvailabilityStatusesHandler : IRequestHandler<GetAvailabilityStatusesQuery, IReadOnlyList<Domain.Entities.AvailabilityStatus>>
{
    private readonly IAvailabilityStatus _availabilityStatusRepository;

    public GetAvailabilityStatusesHandler(IAvailabilityStatus availabilityStatusRepository)
    {
        _availabilityStatusRepository = availabilityStatusRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.AvailabilityStatus>> Handle(GetAvailabilityStatusesQuery request, CancellationToken cancellationToken)
    {
        return _availabilityStatusRepository.GetAllAsync(cancellationToken);
    }
}
