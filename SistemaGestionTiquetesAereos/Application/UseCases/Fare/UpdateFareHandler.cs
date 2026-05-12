using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Fare;

public sealed class UpdateFareHandler : IRequestHandler<UpdateFareCommand>
{
    private readonly IFare _fareRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFareHandler(IFare fareRepository, IUnitOfWork unitOfWork)
    {
        _fareRepository = fareRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateFareCommand request, CancellationToken cancellationToken)
    {
        var entity = await _fareRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Fare), request.Id);

        entity.Update(request.FlightId, request.PassengerTypeId, request.CabinTypeId, request.Amount, request.Currency, request.IsActive);

        _fareRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
