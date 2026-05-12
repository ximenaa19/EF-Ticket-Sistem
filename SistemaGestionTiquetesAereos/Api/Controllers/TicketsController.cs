using AirlineTicketSystem.Api.Dtos.Tickets;
using AirlineTicketSystem.Application.UseCases.Ticket;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class TicketsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public TicketsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<TicketDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<TicketDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetTicketsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<TicketDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(TicketDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TicketDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetTicketByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<TicketDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(TicketDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TicketDto>> Create(CreateTicketRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateTicketCommand(request.ReservationId, request.PassengerId, request.FlightId, request.TicketStatusId, request.TicketNumber, request.FareAmount, request.Currency), cancellationToken);
        var entity = await _sender.Send(new GetTicketByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<TicketDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateTicketRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateTicketCommand(id, request.ReservationId, request.PassengerId, request.FlightId, request.TicketStatusId, request.TicketNumber, request.FareAmount, request.Currency, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteTicketCommand(id), cancellationToken);

        return NoContent();
    }
}
