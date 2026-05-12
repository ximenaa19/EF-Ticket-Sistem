using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airline;

public sealed class DeleteAirlineHandler : IRequestHandler<DeleteAirlineCommand>
{
    private readonly IAirline _airlineRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAirlineHandler(IAirline airlineRepository, IUnitOfWork unitOfWork)
    {
        _airlineRepository = airlineRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteAirlineCommand request, CancellationToken cancellationToken)
    {
        var airline = await _airlineRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Airline), request.Id);

        _airlineRepository.Delete(airline);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
