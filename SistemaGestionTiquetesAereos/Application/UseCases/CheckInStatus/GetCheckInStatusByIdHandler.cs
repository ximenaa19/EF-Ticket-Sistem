using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckInStatus;

public sealed class GetCheckInStatusByIdHandler : IRequestHandler<GetCheckInStatusByIdQuery, Domain.Entities.CheckInStatus>
{
    private readonly ICheckInStatus _checkInStatusRepository;

    public GetCheckInStatusByIdHandler(ICheckInStatus checkInStatusRepository)
    {
        _checkInStatusRepository = checkInStatusRepository;
    }

    public async Task<Domain.Entities.CheckInStatus> Handle(GetCheckInStatusByIdQuery request, CancellationToken cancellationToken)
    {
        return await _checkInStatusRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.CheckInStatus), request.Id);
    }
}
