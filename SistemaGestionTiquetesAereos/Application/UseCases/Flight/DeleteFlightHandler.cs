using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Flight;

public sealed class DeleteFlightHandler : IRequestHandler<DeleteFlightCommand>
{
    private readonly IFlight _flightRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFlightHandler(IFlight flightRepository, IUnitOfWork unitOfWork)
    {
        _flightRepository = flightRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
    {
        var entity = await _flightRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Flight), request.Id);

        _flightRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
