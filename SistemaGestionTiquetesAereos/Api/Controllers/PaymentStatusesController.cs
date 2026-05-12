using AirlineTicketSystem.Api.Dtos.PaymentStatuses;
using AirlineTicketSystem.Application.UseCases.PaymentStatus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PaymentStatusesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public PaymentStatusesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PaymentStatusDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<PaymentStatusDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetPaymentStatusesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<PaymentStatusDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PaymentStatusDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaymentStatusDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetPaymentStatusByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<PaymentStatusDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaymentStatusDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaymentStatusDto>> Create(CreatePaymentStatusRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreatePaymentStatusCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetPaymentStatusByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<PaymentStatusDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdatePaymentStatusRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdatePaymentStatusCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeletePaymentStatusCommand(id), cancellationToken);

        return NoContent();
    }
}
