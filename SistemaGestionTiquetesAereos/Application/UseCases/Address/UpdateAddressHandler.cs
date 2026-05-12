using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Address;

public sealed class UpdateAddressHandler : IRequestHandler<UpdateAddressCommand>
{
    private readonly IAddress _addressRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAddressHandler(IAddress addressRepository, IUnitOfWork unitOfWork)
    {
        _addressRepository = addressRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = await _addressRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Address), request.Id);

        entity.Update(request.RoadTypeId, request.CityId, request.Street, request.Number, request.AdditionalInfo, request.IsActive);

        _addressRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
