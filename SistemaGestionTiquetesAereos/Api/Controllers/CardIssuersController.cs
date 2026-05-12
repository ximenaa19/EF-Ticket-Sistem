using AirlineTicketSystem.Api.Dtos.CardIssuers;
using AirlineTicketSystem.Application.UseCases.CardIssuer;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CardIssuersController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public CardIssuersController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<CardIssuerDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<CardIssuerDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetCardIssuersQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<CardIssuerDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CardIssuerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CardIssuerDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetCardIssuerByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<CardIssuerDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(CardIssuerDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CardIssuerDto>> Create(CreateCardIssuerRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateCardIssuerCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetCardIssuerByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<CardIssuerDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateCardIssuerRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateCardIssuerCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteCardIssuerCommand(id), cancellationToken);

        return NoContent();
    }
}
