using AirlineTicketSystem.Api.Dtos.CardTypes;
using AirlineTicketSystem.Application.UseCases.CardType;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CardTypesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public CardTypesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<CardTypeDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<CardTypeDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetCardTypesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<CardTypeDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CardTypeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CardTypeDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetCardTypeByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<CardTypeDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(CardTypeDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CardTypeDto>> Create(CreateCardTypeRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateCardTypeCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetCardTypeByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<CardTypeDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateCardTypeRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateCardTypeCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteCardTypeCommand(id), cancellationToken);

        return NoContent();
    }
}
