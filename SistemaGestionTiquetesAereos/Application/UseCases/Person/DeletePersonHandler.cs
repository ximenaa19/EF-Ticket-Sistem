using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Person;

public sealed class DeletePersonHandler : IRequestHandler<DeletePersonCommand>
{
    private readonly IPerson _personRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePersonHandler(IPerson personRepository, IUnitOfWork unitOfWork)
    {
        _personRepository = personRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _personRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Person), request.Id);

        _personRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
