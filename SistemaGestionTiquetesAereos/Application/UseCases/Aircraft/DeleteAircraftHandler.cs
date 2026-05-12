using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Aircraft;

public sealed class DeleteAircraftHandler : IRequestHandler<DeleteAircraftCommand>
{
    private readonly IAircraft _aircraftRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAircraftHandler(IAircraft aircraftRepository, IUnitOfWork unitOfWork)
    {
        _aircraftRepository = aircraftRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteAircraftCommand request, CancellationToken cancellationToken)
    {
        var entity = await _aircraftRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Aircraft), request.Id);

        _aircraftRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
