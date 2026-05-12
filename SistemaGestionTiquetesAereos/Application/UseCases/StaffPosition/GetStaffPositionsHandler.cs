using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffPosition;

public sealed class GetStaffPositionsHandler : IRequestHandler<GetStaffPositionsQuery, IReadOnlyList<Domain.Entities.StaffPosition>>
{
    private readonly IStaffPosition _staffPositionRepository;

    public GetStaffPositionsHandler(IStaffPosition staffPositionRepository)
    {
        _staffPositionRepository = staffPositionRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.StaffPosition>> Handle(GetStaffPositionsQuery request, CancellationToken cancellationToken)
    {
        return _staffPositionRepository.GetAllAsync(cancellationToken);
    }
}
