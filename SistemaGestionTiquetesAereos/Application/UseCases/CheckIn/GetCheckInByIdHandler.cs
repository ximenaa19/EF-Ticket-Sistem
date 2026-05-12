using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckIn;

public sealed class GetCheckInByIdHandler : IRequestHandler<GetCheckInByIdQuery, Domain.Entities.CheckIn>
{
    private readonly ICheckIn _checkInRepository;

    public GetCheckInByIdHandler(ICheckIn checkInRepository)
    {
        _checkInRepository = checkInRepository;
    }

    public async Task<Domain.Entities.CheckIn> Handle(GetCheckInByIdQuery request, CancellationToken cancellationToken)
    {
        return await _checkInRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.CheckIn), request.Id);
    }
}
