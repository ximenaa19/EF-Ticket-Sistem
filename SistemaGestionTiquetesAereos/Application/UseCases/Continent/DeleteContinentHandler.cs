using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Continent;

public sealed class DeleteContinentHandler : IRequestHandler<DeleteContinentCommand>
{
    private readonly IContinent _continentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteContinentHandler(IContinent continentRepository, IUnitOfWork unitOfWork)
    {
        _continentRepository = continentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteContinentCommand request, CancellationToken cancellationToken)
    {
        var continent = await _continentRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Continent), request.Id);

        _continentRepository.Delete(continent);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
