using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Continent;

public sealed class UpdateContinentHandler : IRequestHandler<UpdateContinentCommand>
{
    private readonly IContinent _continentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateContinentHandler(IContinent continentRepository, IUnitOfWork unitOfWork)
    {
        _continentRepository = continentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateContinentCommand request, CancellationToken cancellationToken)
    {
        var continent = await _continentRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Continent), request.Id);

        if (await _continentRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException($"Continent with name '{request.Name}' already exists.");
        }

        continent.Update(request.Name, request.IsActive);

        _continentRepository.Update(continent);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
