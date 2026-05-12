using AirlineTicketSystem.Api.Dtos.Routes;
using AirlineTicketSystem.Application.UseCases.Route;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class RoutesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public RoutesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<RouteDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<RouteDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetRoutesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<RouteDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(RouteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RouteDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetRouteByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<RouteDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(RouteDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RouteDto>> Create(CreateRouteRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateRouteCommand(request.OriginAirportId, request.DestinationAirportId, request.DistanceKm), cancellationToken);
        var entity = await _sender.Send(new GetRouteByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<RouteDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateRouteRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateRouteCommand(id, request.OriginAirportId, request.DestinationAirportId, request.DistanceKm, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteRouteCommand(id), cancellationToken);

        return NoContent();
    }
}
