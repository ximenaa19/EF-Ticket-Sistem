using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonEmail;

public sealed class GetPersonEmailsHandler : IRequestHandler<GetPersonEmailsQuery, IReadOnlyList<Domain.Entities.PersonEmail>>
{
    private readonly IPersonEmail _personEmailRepository;

    public GetPersonEmailsHandler(IPersonEmail personEmailRepository)
    {
        _personEmailRepository = personEmailRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.PersonEmail>> Handle(GetPersonEmailsQuery request, CancellationToken cancellationToken)
    {
        return _personEmailRepository.GetAllAsync(cancellationToken);
    }
}
