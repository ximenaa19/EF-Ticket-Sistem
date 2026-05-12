using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Address;

public sealed class CreateAddressHandler : IRequestHandler<CreateAddressCommand, Guid>
{
    private readonly IAddress _addressRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAddressHandler(IAddress addressRepository, IUnitOfWork unitOfWork)
    {
        _addressRepository = addressRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Address(request.RoadTypeId, request.CityId, request.Street, request.Number, request.AdditionalInfo);

        await _addressRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
