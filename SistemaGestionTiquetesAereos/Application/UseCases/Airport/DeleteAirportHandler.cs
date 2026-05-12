using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airport;

public sealed class DeleteAirportHandler : IRequestHandler<DeleteAirportCommand>
{
    private readonly IAirport _airportRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAirportHandler(IAirport airportRepository, IUnitOfWork unitOfWork)
    {
        _airportRepository = airportRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteAirportCommand request, CancellationToken cancellationToken)
    {
        var entity = await _airportRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Airport), request.Id);

        _airportRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
