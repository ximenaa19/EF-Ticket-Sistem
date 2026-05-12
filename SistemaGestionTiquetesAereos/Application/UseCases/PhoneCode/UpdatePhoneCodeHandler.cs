using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PhoneCode;

public sealed class UpdatePhoneCodeHandler : IRequestHandler<UpdatePhoneCodeCommand>
{
    private readonly IPhoneCode _phoneCodeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePhoneCodeHandler(IPhoneCode phoneCodeRepository, IUnitOfWork unitOfWork)
    {
        _phoneCodeRepository = phoneCodeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePhoneCodeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _phoneCodeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PhoneCode), request.Id);

        if (await _phoneCodeRepository.ExistsByCodeAsync(request.Code, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("PhoneCode with Code '" + request.Code + "' already exists.");
        }
        entity.Update(request.CountryId, request.Code, request.IsActive);

        _phoneCodeRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
