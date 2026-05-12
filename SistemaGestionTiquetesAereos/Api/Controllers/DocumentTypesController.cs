using AirlineTicketSystem.Api.Dtos.DocumentTypes;
using AirlineTicketSystem.Application.UseCases.DocumentType;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class DocumentTypesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public DocumentTypesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<DocumentTypeDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<DocumentTypeDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetDocumentTypesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<DocumentTypeDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(DocumentTypeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DocumentTypeDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetDocumentTypeByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<DocumentTypeDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(DocumentTypeDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocumentTypeDto>> Create(CreateDocumentTypeRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateDocumentTypeCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetDocumentTypeByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<DocumentTypeDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateDocumentTypeRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateDocumentTypeCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteDocumentTypeCommand(id), cancellationToken);

        return NoContent();
    }
}
