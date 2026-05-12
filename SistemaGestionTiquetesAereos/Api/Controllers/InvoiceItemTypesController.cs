using AirlineTicketSystem.Api.Dtos.InvoiceItemTypes;
using AirlineTicketSystem.Application.UseCases.InvoiceItemType;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class InvoiceItemTypesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public InvoiceItemTypesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<InvoiceItemTypeDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<InvoiceItemTypeDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetInvoiceItemTypesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<InvoiceItemTypeDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(InvoiceItemTypeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<InvoiceItemTypeDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetInvoiceItemTypeByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<InvoiceItemTypeDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(InvoiceItemTypeDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InvoiceItemTypeDto>> Create(CreateInvoiceItemTypeRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateInvoiceItemTypeCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetInvoiceItemTypeByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<InvoiceItemTypeDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateInvoiceItemTypeRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateInvoiceItemTypeCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteInvoiceItemTypeCommand(id), cancellationToken);

        return NoContent();
    }
}
