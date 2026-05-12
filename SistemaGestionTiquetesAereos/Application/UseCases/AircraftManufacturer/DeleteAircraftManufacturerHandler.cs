using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftManufacturer;

public sealed class DeleteAircraftManufacturerHandler : IRequestHandler<DeleteAircraftManufacturerCommand>
{
    private readonly IAircraftManufacturer _aircraftManufacturerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAircraftManufacturerHandler(IAircraftManufacturer aircraftManufacturerRepository, IUnitOfWork unitOfWork)
    {
        _aircraftManufacturerRepository = aircraftManufacturerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteAircraftManufacturerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _aircraftManufacturerRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.AircraftManufacturer), request.Id);

        _aircraftManufacturerRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
