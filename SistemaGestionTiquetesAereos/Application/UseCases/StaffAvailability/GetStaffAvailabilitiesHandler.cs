using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffAvailability;

public sealed class GetStaffAvailabilitiesHandler : IRequestHandler<GetStaffAvailabilitiesQuery, IReadOnlyList<Domain.Entities.StaffAvailability>>
{
    private readonly IStaffAvailability _staffAvailabilityRepository;

    public GetStaffAvailabilitiesHandler(IStaffAvailability staffAvailabilityRepository)
    {
        _staffAvailabilityRepository = staffAvailabilityRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.StaffAvailability>> Handle(GetStaffAvailabilitiesQuery request, CancellationToken cancellationToken)
    {
        return _staffAvailabilityRepository.GetAllAsync(cancellationToken);
    }
}
