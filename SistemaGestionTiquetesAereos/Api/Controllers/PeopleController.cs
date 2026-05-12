using AirlineTicketSystem.Api.Dtos.People;
using AirlineTicketSystem.Application.UseCases.Person;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PeopleController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public PeopleController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PersonDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<PersonDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetPeopleQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<PersonDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PersonDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetPersonByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<PersonDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(PersonDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonDto>> Create(CreatePersonRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreatePersonCommand(request.FirstName, request.LastName, request.DocumentTypeId, request.DocumentNumber, request.BirthDate, request.AddressId), cancellationToken);
        var entity = await _sender.Send(new GetPersonByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<PersonDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdatePersonRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdatePersonCommand(id, request.FirstName, request.LastName, request.DocumentTypeId, request.DocumentNumber, request.BirthDate, request.AddressId, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeletePersonCommand(id), cancellationToken);

        return NoContent();
    }
}
