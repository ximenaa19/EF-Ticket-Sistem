using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonEmail;

public sealed class DeletePersonEmailHandler : IRequestHandler<DeletePersonEmailCommand>
{
    private readonly IPersonEmail _personEmailRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePersonEmailHandler(IPersonEmail personEmailRepository, IUnitOfWork unitOfWork)
    {
        _personEmailRepository = personEmailRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeletePersonEmailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _personEmailRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PersonEmail), request.Id);

        _personEmailRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
