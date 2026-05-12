using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonEmail;

public sealed class UpdatePersonEmailHandler : IRequestHandler<UpdatePersonEmailCommand>
{
    private readonly IPersonEmail _personEmailRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePersonEmailHandler(IPersonEmail personEmailRepository, IUnitOfWork unitOfWork)
    {
        _personEmailRepository = personEmailRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePersonEmailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _personEmailRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PersonEmail), request.Id);

        entity.Update(request.PersonId, request.EmailDomainId, request.LocalPart, request.IsPrimary, request.IsActive);

        _personEmailRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
