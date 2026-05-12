using AirlineTicketSystem.Api.Dtos.PersonEmails;
using AirlineTicketSystem.Application.UseCases.PersonEmail;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PersonEmailsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public PersonEmailsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PersonEmailDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<PersonEmailDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetPersonEmailsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<PersonEmailDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PersonEmailDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonEmailDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetPersonEmailByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<PersonEmailDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(PersonEmailDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonEmailDto>> Create(CreatePersonEmailRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreatePersonEmailCommand(request.PersonId, request.EmailDomainId, request.LocalPart, request.IsPrimary), cancellationToken);
        var entity = await _sender.Send(new GetPersonEmailByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<PersonEmailDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdatePersonEmailRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdatePersonEmailCommand(id, request.PersonId, request.EmailDomainId, request.LocalPart, request.IsPrimary, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeletePersonEmailCommand(id), cancellationToken);

        return NoContent();
    }
}
