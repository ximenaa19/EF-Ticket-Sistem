using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonEmail;

public sealed class GetPersonEmailByIdHandler : IRequestHandler<GetPersonEmailByIdQuery, Domain.Entities.PersonEmail>
{
    private readonly IPersonEmail _personEmailRepository;

    public GetPersonEmailByIdHandler(IPersonEmail personEmailRepository)
    {
        _personEmailRepository = personEmailRepository;
    }

    public async Task<Domain.Entities.PersonEmail> Handle(GetPersonEmailByIdQuery request, CancellationToken cancellationToken)
    {
        return await _personEmailRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PersonEmail), request.Id);
    }
}
