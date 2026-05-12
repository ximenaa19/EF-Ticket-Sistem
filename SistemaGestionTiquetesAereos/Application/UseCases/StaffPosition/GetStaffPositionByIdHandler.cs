using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffPosition;

public sealed class GetStaffPositionByIdHandler : IRequestHandler<GetStaffPositionByIdQuery, Domain.Entities.StaffPosition>
{
    private readonly IStaffPosition _staffPositionRepository;

    public GetStaffPositionByIdHandler(IStaffPosition staffPositionRepository)
    {
        _staffPositionRepository = staffPositionRepository;
    }

    public async Task<Domain.Entities.StaffPosition> Handle(GetStaffPositionByIdQuery request, CancellationToken cancellationToken)
    {
        return await _staffPositionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.StaffPosition), request.Id);
    }
}
