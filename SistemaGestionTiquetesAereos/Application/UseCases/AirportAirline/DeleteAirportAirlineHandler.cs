using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AirportAirline;

public sealed class DeleteAirportAirlineHandler : IRequestHandler<DeleteAirportAirlineCommand>
{
    private readonly IAirportAirline _airportAirlineRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAirportAirlineHandler(IAirportAirline airportAirlineRepository, IUnitOfWork unitOfWork)
    {
        _airportAirlineRepository = airportAirlineRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteAirportAirlineCommand request, CancellationToken cancellationToken)
    {
        var entity = await _airportAirlineRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.AirportAirline), request.Id);

        _airportAirlineRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
