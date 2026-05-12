using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PhoneCode;

public sealed record GetPhoneCodesQuery : IRequest<IReadOnlyList<Domain.Entities.PhoneCode>>;
