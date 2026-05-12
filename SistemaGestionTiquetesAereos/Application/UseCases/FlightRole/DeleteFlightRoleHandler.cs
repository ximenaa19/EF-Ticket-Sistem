using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightRole;

public sealed class DeleteFlightRoleHandler : IRequestHandler<DeleteFlightRoleCommand>
{
    private readonly IFlightRole _flightRoleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFlightRoleHandler(IFlightRole flightRoleRepository, IUnitOfWork unitOfWork)
    {
        _flightRoleRepository = flightRoleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteFlightRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _flightRoleRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.FlightRole), request.Id);

        _flightRoleRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
