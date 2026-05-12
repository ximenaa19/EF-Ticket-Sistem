using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightRole;

public sealed class UpdateFlightRoleHandler : IRequestHandler<UpdateFlightRoleCommand>
{
    private readonly IFlightRole _flightRoleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFlightRoleHandler(IFlightRole flightRoleRepository, IUnitOfWork unitOfWork)
    {
        _flightRoleRepository = flightRoleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateFlightRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _flightRoleRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.FlightRole), request.Id);

        if (await _flightRoleRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("FlightRole with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _flightRoleRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
