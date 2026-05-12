using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Address;

public sealed class DeleteAddressHandler : IRequestHandler<DeleteAddressCommand>
{
    private readonly IAddress _addressRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAddressHandler(IAddress addressRepository, IUnitOfWork unitOfWork)
    {
        _addressRepository = addressRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = await _addressRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Address), request.Id);

        _addressRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
