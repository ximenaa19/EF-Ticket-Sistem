using AirlineTicketSystem.Api.Dtos.RouteStops;
using AirlineTicketSystem.Application.UseCases.RouteStop;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class RouteStopsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public RouteStopsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<RouteStopDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<RouteStopDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetRouteStopsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<RouteStopDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(RouteStopDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RouteStopDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetRouteStopByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<RouteStopDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(RouteStopDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RouteStopDto>> Create(CreateRouteStopRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateRouteStopCommand(request.RouteId, request.AirportId, request.StopOrder), cancellationToken);
        var entity = await _sender.Send(new GetRouteStopByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<RouteStopDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateRouteStopRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateRouteStopCommand(id, request.RouteId, request.AirportId, request.StopOrder, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteRouteStopCommand(id), cancellationToken);

        return NoContent();
    }
}
