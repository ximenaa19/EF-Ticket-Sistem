using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentStatus;

public sealed record GetPaymentStatusByIdQuery(Guid Id) : IRequest<Domain.Entities.PaymentStatus>;
