using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonPhone;

public sealed class DeletePersonPhoneHandler : IRequestHandler<DeletePersonPhoneCommand>
{
    private readonly IPersonPhone _personPhoneRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePersonPhoneHandler(IPersonPhone personPhoneRepository, IUnitOfWork unitOfWork)
    {
        _personPhoneRepository = personPhoneRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeletePersonPhoneCommand request, CancellationToken cancellationToken)
    {
        var entity = await _personPhoneRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PersonPhone), request.Id);

        _personPhoneRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
