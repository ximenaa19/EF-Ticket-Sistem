using AirlineTicketSystem.Api.Dtos.Invoices;
using AirlineTicketSystem.Application.UseCases.Invoice;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class InvoicesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public InvoicesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<InvoiceDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<InvoiceDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetInvoicesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<InvoiceDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(InvoiceDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<InvoiceDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetInvoiceByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<InvoiceDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(InvoiceDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InvoiceDto>> Create(CreateInvoiceRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateInvoiceCommand(request.ReservationId, request.InvoiceNumber, request.IssuedAt, request.TotalAmount, request.Currency), cancellationToken);
        var entity = await _sender.Send(new GetInvoiceByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<InvoiceDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateInvoiceRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateInvoiceCommand(id, request.ReservationId, request.InvoiceNumber, request.IssuedAt, request.TotalAmount, request.Currency, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteInvoiceCommand(id), cancellationToken);

        return NoContent();
    }
}
