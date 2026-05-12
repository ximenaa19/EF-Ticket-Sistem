using AirlineTicketSystem.Api.Dtos.CabinTypes;
using AirlineTicketSystem.Application.UseCases.CabinType;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CabinTypesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public CabinTypesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<CabinTypeDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<CabinTypeDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetCabinTypesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<CabinTypeDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CabinTypeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CabinTypeDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetCabinTypeByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<CabinTypeDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(CabinTypeDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CabinTypeDto>> Create(CreateCabinTypeRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateCabinTypeCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetCabinTypeByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<CabinTypeDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateCabinTypeRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateCabinTypeCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteCabinTypeCommand(id), cancellationToken);

        return NoContent();
    }
}
