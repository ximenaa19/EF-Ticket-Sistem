using AirlineTicketSystem.Api.Dtos.PaymentMethods;
using AirlineTicketSystem.Application.UseCases.PaymentMethod;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PaymentMethodsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public PaymentMethodsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PaymentMethodDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<PaymentMethodDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetPaymentMethodsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<PaymentMethodDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PaymentMethodDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaymentMethodDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetPaymentMethodByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<PaymentMethodDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaymentMethodDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaymentMethodDto>> Create(CreatePaymentMethodRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreatePaymentMethodCommand(request.ClientId, request.PaymentMethodTypeId, request.CardIssuerId, request.CardTypeId, request.MaskedNumber), cancellationToken);
        var entity = await _sender.Send(new GetPaymentMethodByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<PaymentMethodDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdatePaymentMethodRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdatePaymentMethodCommand(id, request.ClientId, request.PaymentMethodTypeId, request.CardIssuerId, request.CardTypeId, request.MaskedNumber, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeletePaymentMethodCommand(id), cancellationToken);

        return NoContent();
    }
}
