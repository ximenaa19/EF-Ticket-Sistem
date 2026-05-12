using AirlineTicketSystem.Api.Dtos.Payments;
using AirlineTicketSystem.Application.UseCases.Payment;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PaymentsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public PaymentsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PaymentDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<PaymentDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetPaymentsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<PaymentDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PaymentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaymentDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetPaymentByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<PaymentDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaymentDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaymentDto>> Create(CreatePaymentRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreatePaymentCommand(request.ReservationId, request.PaymentMethodId, request.PaymentStatusId, request.Amount, request.Currency, request.PaidAt), cancellationToken);
        var entity = await _sender.Send(new GetPaymentByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<PaymentDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdatePaymentRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdatePaymentCommand(id, request.ReservationId, request.PaymentMethodId, request.PaymentStatusId, request.Amount, request.Currency, request.PaidAt, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeletePaymentCommand(id), cancellationToken);

        return NoContent();
    }
}
