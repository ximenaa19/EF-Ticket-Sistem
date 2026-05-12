using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Fare;

public sealed class CreateFareHandler : IRequestHandler<CreateFareCommand, Guid>
{
    private readonly IFare _fareRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFareHandler(IFare fareRepository, IUnitOfWork unitOfWork)
    {
        _fareRepository = fareRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateFareCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Fare(request.FlightId, request.PassengerTypeId, request.CabinTypeId, request.Amount, request.Currency);

        await _fareRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
