using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AvailabilityStatus;

public sealed class GetAvailabilityStatusByIdHandler : IRequestHandler<GetAvailabilityStatusByIdQuery, Domain.Entities.AvailabilityStatus>
{
    private readonly IAvailabilityStatus _availabilityStatusRepository;

    public GetAvailabilityStatusByIdHandler(IAvailabilityStatus availabilityStatusRepository)
    {
        _availabilityStatusRepository = availabilityStatusRepository;
    }

    public async Task<Domain.Entities.AvailabilityStatus> Handle(GetAvailabilityStatusByIdQuery request, CancellationToken cancellationToken)
    {
        return await _availabilityStatusRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.AvailabilityStatus), request.Id);
    }
}
