using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonPhone;

public sealed record GetPersonPhonesQuery : IRequest<IReadOnlyList<Domain.Entities.PersonPhone>>;
