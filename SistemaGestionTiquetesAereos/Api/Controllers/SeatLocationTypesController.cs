using AirlineTicketSystem.Api.Dtos.SeatLocationTypes;
using AirlineTicketSystem.Application.UseCases.SeatLocationType;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class SeatLocationTypesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public SeatLocationTypesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<SeatLocationTypeDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<SeatLocationTypeDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetSeatLocationTypesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<SeatLocationTypeDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(SeatLocationTypeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SeatLocationTypeDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetSeatLocationTypeByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<SeatLocationTypeDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(SeatLocationTypeDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SeatLocationTypeDto>> Create(CreateSeatLocationTypeRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateSeatLocationTypeCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetSeatLocationTypeByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<SeatLocationTypeDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateSeatLocationTypeRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateSeatLocationTypeCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteSeatLocationTypeCommand(id), cancellationToken);

        return NoContent();
    }
}
