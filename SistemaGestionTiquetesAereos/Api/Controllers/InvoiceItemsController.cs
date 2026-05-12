using AirlineTicketSystem.Api.Dtos.InvoiceItems;
using AirlineTicketSystem.Application.UseCases.InvoiceItem;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class InvoiceItemsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public InvoiceItemsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<InvoiceItemDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<InvoiceItemDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetInvoiceItemsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<InvoiceItemDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(InvoiceItemDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<InvoiceItemDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetInvoiceItemByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<InvoiceItemDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(InvoiceItemDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InvoiceItemDto>> Create(CreateInvoiceItemRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateInvoiceItemCommand(request.InvoiceId, request.InvoiceItemTypeId, request.Description, request.Amount, request.Currency), cancellationToken);
        var entity = await _sender.Send(new GetInvoiceItemByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<InvoiceItemDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateInvoiceItemRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateInvoiceItemCommand(id, request.InvoiceId, request.InvoiceItemTypeId, request.Description, request.Amount, request.Currency, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteInvoiceItemCommand(id), cancellationToken);

        return NoContent();
    }
}
