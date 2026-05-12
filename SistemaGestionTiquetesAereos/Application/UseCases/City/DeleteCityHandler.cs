using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.City;

public sealed class DeleteCityHandler : IRequestHandler<DeleteCityCommand>
{
    private readonly ICity _cityRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCityHandler(ICity cityRepository, IUnitOfWork unitOfWork)
    {
        _cityRepository = cityRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _cityRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.City), request.Id);

        _cityRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
