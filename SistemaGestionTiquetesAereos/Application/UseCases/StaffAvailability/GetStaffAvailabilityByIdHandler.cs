using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffAvailability;

public sealed class GetStaffAvailabilityByIdHandler : IRequestHandler<GetStaffAvailabilityByIdQuery, Domain.Entities.StaffAvailability>
{
    private readonly IStaffAvailability _staffAvailabilityRepository;

    public GetStaffAvailabilityByIdHandler(IStaffAvailability staffAvailabilityRepository)
    {
        _staffAvailabilityRepository = staffAvailabilityRepository;
    }

    public async Task<Domain.Entities.StaffAvailability> Handle(GetStaffAvailabilityByIdQuery request, CancellationToken cancellationToken)
    {
        return await _staffAvailabilityRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.StaffAvailability), request.Id);
    }
}
