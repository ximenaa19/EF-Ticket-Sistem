using AirlineTicketSystem.Api.Dtos.PaymentMethodTypes;
using AirlineTicketSystem.Application.UseCases.PaymentMethodType;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PaymentMethodTypesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public PaymentMethodTypesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PaymentMethodTypeDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<PaymentMethodTypeDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetPaymentMethodTypesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<PaymentMethodTypeDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PaymentMethodTypeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaymentMethodTypeDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetPaymentMethodTypeByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<PaymentMethodTypeDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaymentMethodTypeDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaymentMethodTypeDto>> Create(CreatePaymentMethodTypeRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreatePaymentMethodTypeCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetPaymentMethodTypeByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<PaymentMethodTypeDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdatePaymentMethodTypeRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdatePaymentMethodTypeCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeletePaymentMethodTypeCommand(id), cancellationToken);

        return NoContent();
    }
}
